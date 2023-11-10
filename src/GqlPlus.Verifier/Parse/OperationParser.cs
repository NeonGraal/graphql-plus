using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse;

internal class OperationParser : CommonParser
{
  internal readonly List<ArgumentAst> Variables = new();
  internal readonly List<SpreadAst> Spreads = new();

  public OperationParser(Tokenizer tokens)
    : base(tokens) { }

  internal IResult<OperationAst> Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return Error<OperationAst>("Operation", "text");
      }
    }

    var at = _tokens.At;
    OperationAst ast = new(at);
    if (_tokens.Identifier(out var category)) {
      if (_tokens.Identifier(out var name)) {
        ast = new(at, name) { Category = category };
      } else {
        ast.Category = category;
      }
    }

    var variables = ParseVariables();
    if (!variables.Optional(value => ast.Variables = value)) {
      return variables.AsPartial(Final(), Errors.Add);
    }

    ParseDirectives().Required(directives => ast.Directives = directives);

    ParseFragStart().WithResult(value => ast.Fragments = value);
    if (!_tokens.Prefix(':', out var result, out _)) {
      return Partial("Operation", "identifier to follow ':'", Final);
    }

    if (result is not null) {
      ast.ResultType = result;
      var argument = ParseArgument();
      if (!argument.Optional(value => ast.Argument = value)) {
        return argument.AsPartial(Final());
      }
    } else if (!ParseObject().Required(selections => ast.Object = selections)) {
      return Partial("Operation", "Object or Type", Final);
    }

    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError(Errors.Add)) {
      return modifiers.AsPartial(Final());
    }

    modifiers.WithResult(value => ast.Modifiers = value);
    ParseFragEnd(ast.Fragments).WithResult(value => ast.Fragments = value);

    if (_tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      return Partial("Operation", "no more text", Final);
    }

    return Final().Ok();

    OperationAst Final()
      => ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
  }

  internal IResultArray<VariableAst> ParseVariables()
  {
    var list = new List<VariableAst>();

    if (!_tokens.Take('(')) {
      return list.EmptyArray();
    }

    var variable = ParseVariable();
    if (variable.IsError()) {
      return variable.AsResultArray(list);
    }

    while (variable.Required(list.Add)) {
      variable = ParseVariable();
      if (variable.IsError()) {
        return variable.AsResultArray(list);
      }
    }

    return list.Any()
      ? _tokens.Take(')')
        ? list.OkArray()
        : ErrorArray("Variables", "')'.", list)
      : ErrorArray("Variables", "at least one variable", list);
  }

  internal IResult<VariableAst> ParseVariable()
  {
    var prefix = _tokens.Prefix('$', out var name, out var at);
    var variable = new VariableAst(at, name ?? "");
    if (!prefix) {
      return Error("Variable", "identifier after '$'", variable);
    }

    if (name is null) {
      return variable.Empty();
    }

    if (_tokens.Take(':')) {
      if (!ParseVarType().Required(varType => variable.Type = varType)) {
        return Error("Variable", "type after ':'", variable);
      }
    }

    var modifiers = ParseModifiers("Operation");
    if (!modifiers.Optional(value => variable.Modifers = value)) {
      return modifiers.AsResult(variable);
    }

    var constant = ParseDefault();
    if (!constant.Optional(value => variable.Default = value)) {
      return constant.AsResult(variable);
    }

    var directives = ParseDirectives();
    return directives.Optional(value => variable.Directives = value)
      ? variable.Ok()
      : directives.AsResult(variable);
  }

  internal IResult<string> ParseVarType()
    => ParseVarNull().Select(nullType
      => _tokens.Take('!') ? nullType + '!' : nullType);

  internal IResult<string> ParseVarNull()
  {
    if (_tokens.Take('[')) {
      return ParseVarType().MapOk(
        varType => _tokens.Take(']')
          ? $"[{varType}]".Ok()
          : Error("Variable Type", "an inner variable type", ""),
        () => Error("Variable Type", "an inner variable type", ""));
    } else if (_tokens.Identifier(out var varNull)) {
      return varNull.Ok();
    }

    return "".Empty();
  }

  internal IResultArray<DirectiveAst> ParseDirectives()
  {
    var result = new List<DirectiveAst>();

    if (!_tokens.Prefix('@', out var name, out var at)) {
      return ErrorArray("Directive", "identifier after '@'", result);
    }

    while (name is not null) {
      var directive = new DirectiveAst(at, name);
      var argument = ParseArgument();
      if (!argument.Required(value => directive.Argument = value)) {
        if (argument.IsError()) {
          return argument.AsResultArray(result);
        }
      }

      result.Add(directive);
      if (!_tokens.Prefix('@', out name, out at)) {
        return ErrorArray("Directive", "identifier after '@'", result);
      }
    }

    return result.OkArray();
  }

  internal IResultArray<IAstSelection> ParseObject()
  {
    var fields = new List<IAstSelection>();
    if (!_tokens.Take('{')) {
      return fields.EmptyArray();
    }

    while (!_tokens.Take('}')) {
      var selection = ParseSelection();
      if (selection.IsError()) {
        return selection.AsResultArray(fields);
      } else if (selection.Required(fields.Add)) {
        continue;
      }

      var field = ParseField();
      if (field.IsError()) {
        return field.AsResultArray(fields);
      }

      field.WithResult(fields.Add);
    }

    return fields.Any() ? fields.OkArray() : ErrorArray("Object", "at least one field or selection", fields);
  }

  internal IResult<IAstSelection> ParseSelection()
  {
    if (_tokens.Take("...") || _tokens.Take('|')) {
      var at = _tokens.At;
      string? onType = null;
      if (_tokens.Take("on") || _tokens.Take(':')) {
        if (!_tokens.Identifier(out onType)) {
          return Error<IAstSelection>("Spread", "a type");
        }
      } else {
        if (_tokens.Identifier(out var name)) {
          var selection = new SpreadAst(at, name);
          ParseDirectives().Optional(directives => selection.Directives = directives);
          Spreads.Add(selection);
          return selection.Ok<IAstSelection>();
        }
      }

      {
        var directives = ParseDirectives();
        var selections = ParseObject();
        if (selections.IsOk()) {
          return selections.Select(values => {
            var selection = new InlineAst(at, values) {
              OnType = onType,
            };
            directives.Optional(directives => selection.Directives = directives);
            return selection as IAstSelection;
          });
        }
      }

      return Error<IAstSelection>("Inline", "an object");
    }

    return AstNulls.Selection.Empty();
  }

  internal IResult<IAstSelection> ParseField()
  {
    var at = _tokens.At;
    if (!_tokens.Identifier(out var alias)) {
      return Error<IAstSelection>("Field", "initial identifier");
    }

    var result = new FieldAst(at, alias);

    if (_tokens.Take(':')) {
      at = _tokens.At;
      if (!_tokens.Identifier(out var name)) {
        return Error<IAstSelection>("Field", "a name after an alias");
      }

      result = new FieldAst(at, name) { Alias = alias };
    }

    ParseArgument().Required(argument => result.Argument = argument);

    var modifiers = ParseModifiers("Operation");
    if (!modifiers.Optional(value => result.Modifiers = value)) {
      return modifiers.AsResult<IAstSelection>();
    }

    ParseDirectives().WithResult(directives => result.Directives = directives);

    var selections = ParseObject();
    return !selections.Optional(value => result.Selections = value)
      ? selections.AsResult<IAstSelection>()
      : (result as IAstSelection).Ok();
  }

  internal IResultArray<FragmentAst> ParseFragStart()
    => ParseFragments(
        Array.Empty<FragmentAst>(),
        (ref Tokenizer tokens) => tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take(':')
      );

  internal IResultArray<FragmentAst> ParseFragEnd(FragmentAst[] initial)
    => ParseFragments(
        initial,
        (ref Tokenizer tokens) => tokens.Take("fragment") || tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take("on") || tokens.Take(':')
      );

  private delegate bool Prefix(ref Tokenizer tokens);

  private IResultArray<FragmentAst> ParseFragments(
    FragmentAst[] initial,
    Prefix fragPrefix,
    Prefix typePrefix)
  {
    var definitions = new List<FragmentAst>(initial);

    while (fragPrefix(ref _tokens)) {
      var at = _tokens.At;
      if (!_tokens.Identifier(out var name)) {
        return ErrorArray("Fragment", "name after 'fragment' or '&'", definitions);
      }

      if (!typePrefix(ref _tokens)) {
        return ErrorArray("Fragment", "':' or 'on' after fragment name", definitions);
      }

      if (!_tokens.Identifier(out var onType)) {
        return ErrorArray("Fragment", "type after ':' or 'on'", definitions);
      }

      var directives = ParseDirectives();

      if (directives.IsError()) {
        return directives.AsResultArray(definitions);
      }

      var fields = ParseObject();
      if (!fields.Required(NewFragment)) {
        return fields.AsResultArray(definitions);
      }

      void NewFragment(IAstSelection[] selections)
        => definitions.Add(
          new FragmentAst(at, name, onType, selections) {
            Directives = directives.Optional()
          });
    }

    return definitions.OkArray();
  }

  internal IResult<ArgumentAst> ParseArgument()
  {
    if (!_tokens.Take('(')) {
      return 0.Empty<ArgumentAst>();
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      var at = _tokens.At;
      ArgumentAst? value = new(at);

      var fieldKey = ParseFieldKey();
      if (fieldKey.IsOk()) {
        return fieldKey.Map(key =>
          _tokens.Take(':')
          ? ParseArgValue().MapOk(
            item => ParseArgumentMid(at, new() { [key] = item }),
            () => Error("Argument", "a value after field key separator", value))
          : ParseArgumentEnd(at, key));
      }

      var argValue = ParseArgValue();

      return argValue.MapOk(value => ParseArgumentEnd(at, value), () => argValue);
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  internal IResult<ArgumentAst> ParseArgValue()
  {
    _ = _tokens.At;
    if (!_tokens.Prefix('$', out var variable, out ParseAt? at)) {
      return Error<ArgumentAst>("Argument", "identifier after '$'");
    }

    if (variable is not null) {
      var argument = new ArgumentAst(at, variable);

      Variables.Add(argument);

      return argument.Ok();
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;
      at = _tokens.At;

      var list = ParseArgList();
      if (!list.IsEmpty()) {
        return list.Select(value => new ArgumentAst(at, value));
      }

      var fields = ParseArgObject();
      if (!fields.IsEmpty()) {
        return fields.Select(value => new ArgumentAst(at, value));
      }
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }

    return ParseConstant().MapOk(
      constant => new ArgumentAst(constant).Ok(),
      () => 0.Empty<ArgumentAst>());
  }

  private ArgumentAst ParseArgValues(ArgumentAst initial)
  {
    var at = initial.At;
    var values = new List<ArgumentAst> { initial };
    while (_tokens.Take(',')) {
      ParseArgValue().Required(values.Add);
    }

    return values.Count > 1
      ? new(at, values.ToArray())
      : initial;
  }

  private IResult<ArgumentAst.ObjectAst> ParseArgFieldValues(char end, ArgumentAst.ObjectAst fields)
  {
    var result = new ArgumentAst.ObjectAst(fields);

    while (!_tokens.Take(end)) {
      var field = ParseField("Argument", ParseArgValue);
      if (!field.Required(value => result.Add(value.Key, value.Value))) {
        return Error("Argument", "a field in object", result);
      }

      _tokens.Take(',');
    }

    return result.Ok();
  }

  private IResultArray<ArgumentAst> ParseArgList()
  {
    var list = new List<ArgumentAst>();

    if (!_tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!_tokens.Take(']')) {
      if (!ParseArgValue().Required(list.Add)) {
        return ErrorArray("Argument", "a value in list", list);
      }

      _tokens.Take(',');
    }

    return list.OkArray();
  }

  private IResult<ArgumentAst.ObjectAst> ParseArgObject()
    => _tokens.Take('{')
      ? ParseArgFieldValues('}', new ArgumentAst.ObjectAst())
      : default(ArgumentAst.ObjectAst).Empty();

  private IResult<ArgumentAst> ParseArgumentMid(ParseAt at, ArgumentAst.ObjectAst fields)
  {
    if (_tokens.Take(',')) {
      return ParseArgFieldValues(')', fields).Select(result => new ArgumentAst(at, result));
    }

    while (!_tokens.Take(')')) {
      var field = ParseField("Argument", ParseArgValue);

      if (!field.Required(value => fields.Add(value.Key, ParseArgValues(value.Value)))) {
        return field.AsResult<ArgumentAst>();
      }
    }

    return new ArgumentAst(at, fields).Ok();
  }

  private IResult<ArgumentAst> ParseArgumentEnd(ParseAt at, ArgumentAst value)
  {
    var more = ParseArgValues(value);
    if (more.Values.Length > 1) {
      return more.Ok();
    }

    var values = new List<ArgumentAst> { value };
    while (ParseArgValue().Required(values.Add)) { }

    if (_tokens.Take(")")) {
      var argument = values.Count > 1 ? new(at, values.ToArray()) : value;
      return argument.Ok();
    }

    return Error("Argument", "a value", more);
  }
}
