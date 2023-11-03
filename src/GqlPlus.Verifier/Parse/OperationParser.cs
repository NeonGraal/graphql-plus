using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse;

internal class OperationParser : CommonParser
{
  internal readonly List<ArgumentAst> Variables = new();
  internal readonly List<SpreadAst> Spreads = new();

  public OperationParser(Tokenizer tokens)
    : base(tokens) { }

  internal OperationAst Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return new(_tokens.At) { Errors = new[] { _tokens.Error("Unexpected") } };
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

    ast.Fragments = ParseFragStart();
    if (!_tokens.Prefix(':', out var result, out _)) {
      Error("Operation", "identifier to follow ':'");
      return ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
    }

    if (result is not null) {
      ast.ResultType = result;
      if (ParseArgument().Required(out var argument)) {
        ast.Argument = argument;
      }
    } else if (ParseObject(out IAstSelection[] selections)) {
      ast.Object = selections;
    } else {
      Error("Operation", "Object or Type");
      return ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
    }

    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError(Errors.Add)) {
      return ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
    }

    modifiers.WithResult(value => ast.Modifiers = value);
    ast.Fragments = ParseFragEnd(ast.Fragments);

    if (_tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      Error("Operation", "no more text");
    }

    return ast with {
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

    if (!_tokens.Prefix('$', out var name, out var at)) {
      return ErrorArray("Variables", "identifier after '$'", list);
    }

    while (name is not null) {
      var variable = new VariableAst(at, name);

      if (_tokens.Take(':')
        && ParseVarType().Required(out var varType)
      ) {
        variable.Type = varType;
      }

      var modifiers = ParseModifiers("Operation");

      if (modifiers.IsError()) {
        return modifiers.AsResultArray(variable);
      }

      modifiers.WithResult(value => variable.Modifers = value);

      if (ParseDefault().Required(out var constant)) {
        variable.Default = constant;
      }

      if (ParseDirectives().Required(out var directives)) {
        variable.Directives = directives;
      }

      list.Add(variable);
      if (!_tokens.Prefix('$', out name, out at)) {
        return ErrorArray("Variables", "identifier after '$'", list);
      }
    }

    return !list.Any()
      ? ErrorArray("Variables", "at least one variable", list)
      : _tokens.Take(')') ? list.OkArray() : ErrorArray("Variables", "')'.", list);
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

  internal bool ParseObject(out IAstSelection[] selections)
  {
    selections = Array.Empty<IAstSelection>();
    if (!_tokens.Take('{')) {
      return false;
    }

    var fields = new List<IAstSelection>();

    while (!_tokens.Take('}')) {
      if (ParseSelection().Required(out var fragment)) {
        fields.Add(fragment);
      } else if (ParseField().Required(out var field)) {
        fields.Add(field);
      } else {
        selections = fields.ToArray();

        return Error("Object", "a field or selection");
      }
    }

    selections = fields.ToArray();
    return Error("Object", "at least one field or selection", fields.Any());
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
          if (ParseObject(out IAstSelection[] selections)) {
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
      return modifiers.AsResult(AstNulls.Selection);
    }

    modifiers.WithResult(value => result.Modifiers = value);
    if (ParseDirectives().Required(out var directives)) {
      result.Directives = directives;
    }

    if (ParseObject(out IAstSelection[] selections)) {
      result.Selections = selections;
    }

    return (result as IAstSelection).Ok();
  }

  internal FragmentAst[] ParseFragStart()
    => ParseFragment(
        Array.Empty<FragmentAst>(),
        (ref Tokenizer tokens) => tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take(':')
      );

  internal FragmentAst[] ParseFragEnd(FragmentAst[] initial)
    => ParseFragment(
        initial,
        (ref Tokenizer tokens) => tokens.Take("fragment") || tokens.Take('&'),
        (ref Tokenizer tokens) => tokens.Take("on") || tokens.Take(':')
      );

  private delegate bool Prefix(ref Tokenizer tokens);

  private FragmentAst[] ParseFragment(
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
          if (ParseObject(out IAstSelection[] selections)) {
            var fragment = new FragmentAst(at, name, onType, selections) { Directives = directives };
            definitions.Add(fragment);
          }
        }
      }
    }

    return definitions.ToArray();
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

      if (ParseArgList(out ArgumentAst[] list)) {
        return new ArgumentAst(at, list).Ok();
      }

      if (ParseArgObject(out AstValues<ArgumentAst>.ObjectAst fields)) {
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

  private bool ParseArgFieldValues(char end, ArgumentAst.ObjectAst fields)
  {
    var result = new ArgumentAst.ObjectAst(fields);
    fields.Clear();

    while (!_tokens.Take(end)) {
      if (ParseFieldKey().Required(out var key)
        && _tokens.Take(':')
        && ParseArgValue().Required(out var value)
      ) {
        result.Add(key, value);
      } else {
        return Error("Argument", "a field in object");
      }

      _tokens.Take(',');
    }

    foreach (var item in result) {
      fields.Add(item.Key, item.Value);
    }

    return true;
  }

  private bool ParseArgList(out ArgumentAst[] list)
  {
    list = Array.Empty<ArgumentAst>();

    if (!_tokens.Take('[')) {
      return false;
    }

    var values = new List<ArgumentAst>();
    while (!_tokens.Take(']')) {
      if (ParseArgValue().Required(out var item)) {
        values.Add(item);
      } else {
        return Error("Argument", "a value in list");
      }

      _tokens.Take(',');
    }

    list = values.ToArray();
    return true;
  }

  private bool ParseArgObject(out ArgumentAst.ObjectAst fields)
  {
    fields = new ArgumentAst.ObjectAst();

    return _tokens.Take('{')
      && ParseArgFieldValues('}', fields);
  }

  private IResult<ArgumentAst> ParseArgumentMid(ParseAt at, ArgumentAst.ObjectAst fields)
  {
    if (_tokens.Take(',')) {
      return ParseArgFieldValues(')', fields) ? new ArgumentAst(at, fields).Ok() : Error<ArgumentAst>("Argument", "a field after ','");
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
