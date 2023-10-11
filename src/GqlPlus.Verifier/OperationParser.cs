using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

internal ref struct OperationParser
{
  private Tokenizer _tokens;

  internal readonly List<ParseError> _errors = new();

  public OperationParser(Tokenizer tokens)
    => _tokens = tokens;

  internal OperationAst? Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return new() { Errors = new[] { _tokens.Error("Unexpected") } };
      }
    }

    OperationAst ast = new();

    if (_tokens.Identifier(out var category)) {
      if (_tokens.Identifier(out var name)) {
        ast = new(name) { Category = category };
      } else {
        ast.Category = category;
      }
    }

    if (ParseVariables(out VariableAst[] variables)) {
      ast.Variables = variables;
    }

    ast.Directives = ParseDirectives();

    if (_tokens.Prefix(':', out var result)) {
      ast.ResultType = result;
      if (ParseArgument(out var argument)) {
        ast.Argument = argument;
      }
    } else if (ParseObject(out AstSelection[] selections)) {
      ast.Object = selections;
    } else {
      Error("Result not present. Expected Object or Type.");
      return ast with { Errors = _errors.ToArray() };
    }

    ast.Modifiers = ParseModifiers();
    ast.Fragments = ParseFragments();

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    } else {
      Error("Text beyond end of Operation.");
    }

    return ast with { Errors = _errors.ToArray() };
  }

  internal bool ParseVariables(out VariableAst[] variables)
  {
    variables = Array.Empty<VariableAst>();
    if (!_tokens.Take('(')) {
      return false;
    }

    var result = new List<VariableAst>();

    while (_tokens.Prefix('$', out var name)) {
      var variable = new VariableAst(name);

      if (_tokens.Take(':') && _tokens.Identifier(out var varType)) {
        variable.Type = varType;
      }

      variable.Modifers = ParseModifiers();
      if (_tokens.Take('=') && ParseConstant(out var constant)) {
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

  internal DirectiveAst[] ParseDirectives()
  {
    var directives = new List<DirectiveAst>();

    while (_tokens.Prefix('@', out var name)) {
      var directive = new DirectiveAst(name);
      if (ParseArgument(out ArgumentAst? argument)) {
        directive.Argument = argument;
      }

      directives.Add(directive);
    }

    return directives.ToArray();
  }

  internal ModifierAst[] ParseModifiers()
  {
    var modifiers = new List<ModifierAst>();

    while (_tokens.Take('[')) {
      ModifierAst modifier = ModifierAst.List;
      if (_tokens.Identifier(out var key)) {
        modifier = new(key, _tokens.Take('?'));
      } else {
        if (_tokens.TakeAny(out var charType, '~', '0', '*')) {
          modifier = new(charType.ToString(), _tokens.Take('?'));
        }
      }

      if (_tokens.Take(']')) {
        modifiers.Add(modifier);
      }
    }

    if (_tokens.Take('?')) {
      modifiers.Add(ModifierAst.Optional);
    }

    return modifiers.ToArray();
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
      string? onType = null;
      if (_tokens.Take("on") || _tokens.Take(':')) {
        if (!_tokens.Identifier(out onType)) {
          return Error("Invalid Spread. Expected a type.");
        }
      } else {
        if (_tokens.Identifier(out var name)) {
          selection = new SpreadAst(name) { Directives = ParseDirectives() };
          return true;
        }
      }

      DirectiveAst[] directives = ParseDirectives();

      if (ParseObject(out AstSelection[] selections)) {
        selection = new InlineAst(selections) {
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
    field = AstNulls.Selection;

    if (!_tokens.Identifier(out var alias)) {
      return false;
    }

    var result = new FieldAst(alias);

    if (_tokens.Take(':')) {
      if (!_tokens.Identifier(out var name)) {
        return Error("Invalid Field. Expected Name after Alias");
      }

      result = new FieldAst(name) { Alias = alias };
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

  internal FragmentAst[] ParseFragments()
  {
    var definitions = new List<FragmentAst>();

    while (_tokens.Take("fragment") || _tokens.Take('&')) {
      if (_tokens.Identifier(out var name) &&
        (_tokens.Take("on") || _tokens.Take(':')) &&
        _tokens.Identifier(out var onType)
      ) {
        DirectiveAst[] directives = ParseDirectives();
        if (ParseObject(out AstSelection[] selections)) {
          var fragment = new FragmentAst(name, onType, selections) { Directives = directives };
          definitions.Add(fragment);
        }
      }
    }

    return definitions.ToArray();
  }

  internal bool ParseArgument(out ArgumentAst argument)
  {
    argument = new ArgumentAst();

    if (!_tokens.Take('(')) {
      return false;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      ArgumentAst value = new();
      if (ParseFieldKey(out var key)) {
        value = key;
        return _tokens.Take(':')
          ? ParseArgValue(out var item)
            && ParseArgValues(item, out var items)
            && ParseArgumentMid(new() { [key] = items }, out argument)
          : ParseArgumentEnd(value, out argument);
      }

      return ParseArgValue(out value)
        && ParseArgumentEnd(value, out argument);
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  internal bool ParseArgValue(out ArgumentAst argument)
  {
    argument = new ArgumentAst();

    if (_tokens.Prefix('$', out var variable)) {
      argument = new ArgumentAst(variable);
      return true;
    }

    if (ParseArgList(out ArgumentAst[] list)) {
      argument = new ArgumentAst(list);
      return true;
    }

    if (ParseArgObject(out AstValues<ArgumentAst>.ObjectAst fields)) {
      argument = new ArgumentAst(fields);
      return true;
    }

    if (ParseConstant(out ConstantAst constant)) {
      argument = constant;
      return true;
    }

    return false;
  }

  private bool ParseArgValues(ArgumentAst initial, out ArgumentAst argument)
  {
    argument = new ArgumentAst();

    var values = new List<ArgumentAst> { initial };
    while (_tokens.Take(',')) {
      if (!ParseArgValue(out ArgumentAst value)) {
        return Error("Invalid Argument. Possibly missing ',', ')', ']' or '}' in Values.");
      }

      values.Add(value);
    }

    argument = values.Count > 1
      ? new(values.ToArray())
      : initial;

    return true;
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

      _tokens.Take(';');
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

  internal bool ParseFieldKey(out FieldKeyAst constant)
  {
    constant = new FieldKeyAst();

    if (_tokens.Number(out var number)) {
      constant = new FieldKeyAst(number);
      return true;
    }

    if (_tokens.String(out var contents)) {
      constant = new FieldKeyAst(contents);
      return true;
    }

    if (_tokens.Identifier(out var identifier)) {
      if (_tokens.Take('.') && _tokens.Identifier(out var label)) {
        constant = new FieldKeyAst(identifier, label);
        return true;
      }

      constant = new FieldKeyAst("", identifier);
      return true;
    }

    return false;
  }

  internal bool ParseConstant(out ConstantAst constant)
  {
    constant = new ConstantAst();

    if (ParseFieldKey(out FieldKeyAst fieldKey)) {
      constant = fieldKey;
      return true;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    try {
      _tokens.IgnoreSeparators = false;

      if (ParseConstList(out ConstantAst[] list)) {
        constant = new ConstantAst(list);
        return true;
      }

      if (ParseConstObject(out AstValues<ConstantAst>.ObjectAst fields)) {
        constant = new ConstantAst(fields);
        return true;
      }

      return false;
    } finally {
      _tokens.IgnoreSeparators = oldSeparators;
    }
  }

  private bool ParseConstList(out ConstantAst[] list)
  {
    list = Array.Empty<ConstantAst>();

    if (!_tokens.Take('[')) {
      return false;
    }

    var values = new List<ConstantAst>();
    while (!_tokens.Take(']')) {
      if (ParseConstant(out var item)) {
        values.Add(item);
      } else {
        return Error("Invalid Constant. Possibly missing ',' or ']' in List.");
      }

      _tokens.Take(',');
    }

    list = values.ToArray();
    return true;
  }

  private bool ParseConstObject(out ConstantAst.ObjectAst fields)
  {
    fields = new ConstantAst.ObjectAst();
    if (!_tokens.Take('{')) {
      return false;
    }

    while (!_tokens.Take('}')) {
      if (ParseFieldKey(out var key)
        && _tokens.Take(':')
        && ParseConstant(out var value)
      ) {
        fields.Add(key, value);
      } else {
        Error("Invalid Constant. Possibly missing ':' or '}' in Field.");
        return false;
      }

      _tokens.Take(';');
    }

    return true;
  }

  private bool ParseArgumentMid(ArgumentAst.ObjectAst fields, out ArgumentAst argument)
  {
    argument = new();

    if (_tokens.Take(';')) {
      if (ParseArgFieldValues(')', fields)) {
        argument = new ArgumentAst(fields);
        return true;
      }

      return Error("Invalid Argument. Expected Field Values after ';'");
    }

    while (!_tokens.Take(')')) {
      if (ParseFieldKey(out var key1)
        && _tokens.Take(":")
        && ParseArgValue(out var item1)
      ) {
        if (!ParseArgValues(item1, out var items1)) {
          return false;
        }

        fields.Add(key1, items1);
      } else {
        return Error("Invalid Argument. Possibly missing ')' after Fields.");
      }
    }

    argument = new ArgumentAst(fields);
    return true;
  }

  private bool ParseArgumentEnd(ArgumentAst value, out ArgumentAst argument)
  {
    if (ParseArgValues(value, out var more) && more.Values.Length > 1) {
      argument = more;
      return true;
    }

    var values = new List<ArgumentAst> { value };
    while (ParseArgValue(out var item)) {
      values.Add(item);
    }

    if (_tokens.Take(")")) {
      argument = values.Count > 1 ? new(values.ToArray()) : value;
      return true;
    }

    argument = new();
    return Error("Invalid Argument. Possibly missing ')' after Values.");
  }

  private bool Error(string message, bool result = false)
  {
    if (!result) {
      _errors.Add(_tokens.Error(message));
    }

    return result;
  }
}
