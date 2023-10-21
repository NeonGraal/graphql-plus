using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier;

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

    if (ParseVariables(out VariableAst[] variables)) {
      ast.Variables = variables;
    }

    ast.Directives = ParseDirectives();
    ast.Fragments = ParseFragStart();
    if (_tokens.Prefix(':', out var result, out _)) {
      ast.ResultType = result;
      if (ParseArgument(out var argument)) {
        ast.Argument = argument;
      }
    } else if (ParseObject(out AstSelection[] selections)) {
      ast.Object = selections;
    } else {
      Error("Result not present. Expected Object or Type.");
      return ast with {
        Errors = Errors.ToArray(),
        Usages = Variables.ToArray(),
        Spreads = Spreads.ToArray(),
      };
    }

    ast.Modifiers = ParseModifiers();
    ast.Fragments = ParseFragEnd(ast.Fragments);

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    } else {
      Error("Text beyond end of Operation.");
    }

    return ast with {
      Errors = Errors.ToArray(),
      Usages = Variables.ToArray(),
      Spreads = Spreads.ToArray(),
    };
  }

  internal bool ParseVariables(out VariableAst[] variables)
  {
    variables = Array.Empty<VariableAst>();
    if (!_tokens.Take('(')) {
      return false;
    }

    var result = new List<VariableAst>();

    while (_tokens.Prefix('$', out var name, out var at)) {
      var variable = new VariableAst(at, name);

      if (_tokens.Take(':')
        && ParseVarType(out var varType)
      ) {
        variable.Type = varType;
      }

      variable.Modifers = ParseModifiers();
      if (_tokens.Take('=')
        && ParseConstant(out var constant)
      ) {
        variable.Default = constant;
      }

      variable.Directives = ParseDirectives();

      result.Add(variable);
    }

    if (!result.Any()) {
      return Error("Invalid Variables. No variables defined.");
    }

    variables = result.ToArray();

    return Error("Invalid Variables. Expected ')'.", _tokens.Take(')'));
  }

  internal bool ParseVarType(out string varType)
  {
    if (ParseVarNull(out var nullType)) {
      varType = _tokens.Take('!') ? nullType + '!' : nullType;
      return true;
    }

    varType = "";
    return false;
  }

  internal bool ParseVarNull(out string varNull)
  {
    if (_tokens.Take('[')) {
      if (ParseVarType(out var varType)
        && _tokens.Take(']')
      ) {
        varNull = "[" + varType + "]";
        return true;
      }

      varNull = "";
      return Error("Invalid Variable Type. Expected an inner variable type.");
    } else {
      return _tokens.Identifier(out varNull);
    }
  }

  internal DirectiveAst[] ParseDirectives()
  {
    var directives = new List<DirectiveAst>();

    while (_tokens.Prefix('@', out var name, out var at)) {
      var directive = new DirectiveAst(at, name);
      if (ParseArgument(out ArgumentAst? argument)) {
        directive.Argument = argument;
      }

      directives.Add(directive);
    }

    return directives.ToArray();
  }

  internal bool ParseObject(out AstSelection[] selections)
  {
    selections = Array.Empty<AstSelection>();
    if (!_tokens.Take('{')) {
      return false;
    }

    var fields = new List<AstSelection>();

    while (!_tokens.Take('}')) {
      if (ParseSelection(out AstSelection fragment)) {
        fields.Add(fragment);
      } else if (ParseField(out AstSelection field)) {
        fields.Add(field);
      } else {
        selections = fields.ToArray();

        return Error("Invalid Object. Expected Field or Selection.");
      }
    }

    selections = fields.ToArray();
    return Error("Invalid Object. Expected at least one Field or Selection", fields.Any());
  }

  internal bool ParseSelection(out AstSelection selection)
  {
    selection = AstNulls.Selection;

    if (_tokens.Take("...") || _tokens.Take('|')) {
      var at = _tokens.At;
      string? onType = null;
      if (_tokens.Take("on") || _tokens.Take(':')) {
        if (!_tokens.Identifier(out onType)) {
          return Error("Invalid Spread. Expected a type.");
        }
      } else {
        if (_tokens.Identifier(out var name)) {
          selection = new SpreadAst(at, name) { Directives = ParseDirectives() };
          Spreads.Add((SpreadAst)selection);
          return true;
        }
      }

      DirectiveAst[] directives = ParseDirectives();

      if (ParseObject(out AstSelection[] selections)) {
        selection = new InlineAst(at, selections) {
          OnType = onType,
          Directives = directives,
        };
        return true;
      }

      return Error("Invalid Inline. Expected Object.");
    }

    return false;
  }

  internal bool ParseField(out AstSelection field)
  {
    var at = _tokens.At;
    field = AstNulls.Selection;

    if (!_tokens.Identifier(out var alias)) {
      return false;
    }

    var result = new FieldAst(at, alias);

    if (_tokens.Take(':')) {
      at = _tokens.At;
      if (!_tokens.Identifier(out var name)) {
        return Error("Invalid Field. Expected Name after Alias");
      }

      result = new FieldAst(at, name) { Alias = alias };
    }

    if (ParseArgument(out ArgumentAst argument)) {
      result.Argument = argument;
    }

    result.Modifiers = ParseModifiers();
    result.Directives = ParseDirectives();

    if (ParseObject(out AstSelection[] selections)) {
      result.Selections = selections;
    }

    field = result;
    return true;
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
        DirectiveAst[] directives = ParseDirectives();
        if (ParseObject(out AstSelection[] selections)) {
          var fragment = new FragmentAst(at, name, onType, selections) { Directives = directives };
          definitions.Add(fragment);
        }
      }
    }

    return definitions.ToArray();
  }

  internal bool ParseArgument(out ArgumentAst argument)
  {
    argument = new ArgumentAst(_tokens.At);

    if (!_tokens.Take('(')) {
      return false;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      var at = _tokens.At;
      ArgumentAst value = new(at);
      if (ParseFieldKey(out var key)) {
        value = key;
        return _tokens.Take(':')
          ? ParseArgValue(out var item)
            ? ParseArgumentMid(at, new() { [key] = item }, out argument)
            : Error("Invalid Argument. Value not found after Field key separator.")
          : ParseArgumentEnd(at, value, out argument);
      }

      return ParseArgValue(out value)
        && ParseArgumentEnd(at, value, out argument);
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  internal bool ParseArgValue(out ArgumentAst argument)
  {
    var at = _tokens.At;
    argument = new ArgumentAst(at);

    if (_tokens.Prefix('$', out var variable, out at)) {
      argument = new ArgumentAst(at, variable);

      Variables.Add(argument);

      return true;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      if (ParseArgList(out ArgumentAst[] list)) {
        argument = new ArgumentAst(at, list);
        return true;
      }

      if (ParseArgObject(out AstValues<ArgumentAst>.ObjectAst fields)) {
        argument = new ArgumentAst(at, fields);
        return true;
      }
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }

    if (ParseConstant(out ConstantAst constant)) {
      argument = constant;
      return true;
    }

    return false;
  }

  private ArgumentAst ParseArgValues(ArgumentAst initial)
  {
    var at = initial.At;
    var values = new List<ArgumentAst> { initial };
    while (_tokens.Take(',')) {
      if (ParseArgValue(out ArgumentAst value)) {
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
      if (ParseFieldKey(out var key)
        && _tokens.Take(':')
        && ParseArgValue(out var value)
      ) {
        result.Add(key, value);
      } else {
        return Error($"Invalid Argument. Possibly missing ':' or '{end}' in Field.");
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
      if (ParseArgValue(out var item)) {
        values.Add(item);
      } else {
        return Error("Invalid Argument. Possibly missing ',' or ']' in List.");
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

  private bool ParseArgumentMid(ParseAt at, ArgumentAst.ObjectAst fields, out ArgumentAst argument)
  {
    argument = new(at);

    if (_tokens.Take(',')) {
      if (ParseArgFieldValues(')', fields)) {
        argument = new ArgumentAst(at, fields);
        return true;
      }

      return Error("Invalid Argument. Expected Field Values after ','");
    }

    while (!_tokens.Take(')')) {
      if (ParseFieldKey(out var key1)
        && _tokens.Take(":")
        && ParseArgValue(out var item1)
      ) {
        fields.Add(key1, ParseArgValues(item1));
      } else {
        return Error("Invalid Argument. Possibly missing ')' after Fields.");
      }
    }

    argument = new ArgumentAst(at, fields);
    return true;
  }

  private bool ParseArgumentEnd(ParseAt at, ArgumentAst value, out ArgumentAst argument)
  {
    var more = ParseArgValues(value);
    if (more.Values.Length > 1) {
      argument = more;
      return true;
    }

    var values = new List<ArgumentAst> { value };
    while (ParseArgValue(out var item)) {
      values.Add(item);
    }

    if (_tokens.Take(")")) {
      argument = values.Count > 1 ? new(at, values.ToArray()) : value;
      return true;
    }

    argument = new(at);
    return Error("Invalid Argument. Possibly missing ')' after Values.");
  }
}
