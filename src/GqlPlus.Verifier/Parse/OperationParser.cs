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

    if (ParseVariables().Required(out var variables)) {
      ast.Variables = variables;
    }

    if (ParseDirectives().Required(out var directives)) {
      ast.Directives = directives;
    }

    ParseFragStart().WithResult(value => ast.Fragments = value);
    if (!_tokens.Prefix(':', out var result, out _)) {
      return Partial("Operation", "identifier to follow ':'", Final);
    }

    if (result is not null) {
      ast.ResultType = result;
      if (ParseArgument().Required(out var argument)) {
        ast.Argument = argument;
      }
    } else if (!ParseObject().Required(selections => ast.Object = selections)) {
      return Partial("Operation", "Object or Type", Final);
    }

    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError(Errors.Add)) {
      return modifiers.AsResult(ast);
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
  {
    if (ParseVarNull().Required(out var nullType)) {
      var varType = _tokens.Take('!') ? nullType + '!' : nullType;
      return varType.Ok();
    }

    return "".Empty();
  }

  internal IResult<string> ParseVarNull()
  {
    if (_tokens.Take('[')) {
      return ParseVarType().Required(out var varType)
        && _tokens.Take(']')
        ? $"[{varType}]".Ok()
        : Error("Variable Type", "an inner variable type", "");
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
      if (argument.Required(out var value)) {
        directive.Argument = value;
      } else if (argument.IsError()) {
        return argument.AsResultArray(result);
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
      } else if (!field.Required(fields.Add)) {
        return ErrorArray("Object", "a field or selection", fields);
      }
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
          if (ParseDirectives().Required(out var directives)) {
            IAstSelection selection = new SpreadAst(at, name) { Directives = directives };
            Spreads.Add((SpreadAst)selection);
            return selection.Ok();
          }
        }
      }

      {
        if (ParseDirectives().Required(out var directives)) {
          if (ParseObject().Required(out IAstSelection[] selections)) {
            IAstSelection selection = new InlineAst(at, selections) {
              OnType = onType,
              Directives = directives,
            };
            return selection.Ok();
          }
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

    if (ParseArgument().Required(out var argument)) {
      result.Argument = argument;
    }

    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError()) {
      return modifiers.AsResult<IAstSelection>();
    }

    modifiers.WithResult(value => result.Modifiers = value);
    if (ParseDirectives().Required(out var directives)) {
      result.Directives = directives;
    }

    var selections = ParseObject();
    return !selections.Optional(value => result.Selections = value)
      ? selections.AsResult<IAstSelection>()
      : (result as IAstSelection).Ok();
  }

  internal IResultArray<FragmentAst> ParseFragStart()
    => ParseFragment(
        Array.Empty<FragmentAst>(),
        (ref Tokenizer tokens) => tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take(':')
      );

  internal IResultArray<FragmentAst> ParseFragEnd(FragmentAst[] initial)
    => ParseFragment(
        initial,
        (ref Tokenizer tokens) => tokens.Take("fragment") || tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take("on") || tokens.Take(':')
      );

  private delegate bool Prefix(ref Tokenizer tokens);

  private IResultArray<FragmentAst> ParseFragment(
    FragmentAst[] initial,
    Prefix fragPrefix,
    Prefix typePrefix)
  {
    var definitions = new List<FragmentAst>(initial);

    while (fragPrefix(ref _tokens)) {
      var at = _tokens.At;
      if (_tokens.Identifier(out var name)
        && typePrefix(ref _tokens)
        && _tokens.Identifier(out var onType)
      ) {
        if (ParseDirectives().Required(out var directives)) {
          if (ParseObject().Required(out IAstSelection[] selections)) {
            var fragment = new FragmentAst(at, name, onType, selections) { Directives = directives };
            definitions.Add(fragment);
          }
        }
      }
    }

    return definitions.OkArray();
  }

  internal IResult<ArgumentAst> ParseArgument()
  {
    if (!_tokens.Take('(')) {
      return new ResultEmpty<ArgumentAst>();
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      var at = _tokens.At;
      ArgumentAst? value = new(at);
      if (ParseFieldKey().Required(out var key)) {
        value = key;
        return _tokens.Take(':')
          ? ParseArgValue().Required(out var item)
            ? ParseArgumentMid(at, new() { [key] = item })
            : Error("Argument", "a value after field key separator", value)
          : ParseArgumentEnd(at, value);
      }

      var argValue = ParseArgValue();

      return argValue.Required(out value)
        ? ParseArgumentEnd(at, value)
        : argValue;
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

      if (ParseArgList().Required(out ArgumentAst[] list)) {
        return new ArgumentAst(at, list).Ok();
      }

      if (ParseArgObject().Required(out var fields)) {
        return new ArgumentAst(at, fields).Ok();
      }
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }

    return ParseConstant().Required(out var constant) ? new ArgumentAst(constant).Ok() : (IResult<ArgumentAst>)new ResultEmpty<ArgumentAst>();
  }

  private ArgumentAst ParseArgValues(ArgumentAst initial)
  {
    var at = initial.At;
    var values = new List<ArgumentAst> { initial };
    while (_tokens.Take(',')) {
      if (ParseArgValue().Required(out var value)) {
        values.Add(value);
      }
    }

    return values.Count > 1
      ? new(at, values.ToArray())
      : initial;
  }

  private IResult<ArgumentAst.ObjectAst> ParseArgFieldValues(char end, ArgumentAst.ObjectAst fields)
  {
    var result = new ArgumentAst.ObjectAst(fields);

    while (!_tokens.Take(end)) {
      if (ParseFieldKey().Required(out var key)
        && _tokens.Take(':')
        && ParseArgValue().Required(out var value)
      ) {
        result.Add(key, value);
      } else {
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
      if (ParseArgValue().Required(out var item)) {
        list.Add(item);
      } else {
        return ErrorArray("Argument", "a value in list", list);
      }

      _tokens.Take(',');
    }

    return list.OkArray();
  }

  private IResult<ArgumentAst.ObjectAst> ParseArgObject()
    => _tokens.Take('{')
      ? ParseArgFieldValues('}', new ArgumentAst.ObjectAst())
      : new ResultEmpty<ArgumentAst.ObjectAst>();

  private IResult<ArgumentAst> ParseArgumentMid(ParseAt at, ArgumentAst.ObjectAst fields)
  {
    if (_tokens.Take(',')) {
      return ParseArgFieldValues(')', fields).Required(out var result)
        ? new ArgumentAst(at, result).Ok()
        : Error<ArgumentAst>("Argument", "a field after ','");
    }

    while (!_tokens.Take(')')) {
      if (ParseFieldKey().Required(out var key1)
        && _tokens.Take(":")
        && ParseArgValue().Required(out var item1)
      ) {
        fields.Add(key1, ParseArgValues(item1));
      } else {
        return Error<ArgumentAst>("Argument", "a field");
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
    while (ParseArgValue().Required(out var item)) {
      values.Add(item);
    }

    if (_tokens.Take(")")) {
      var argument = values.Count > 1 ? new(at, values.ToArray()) : value;
      return argument.Ok();
    }

    return Error("Argument", "a value", more);
  }
}
