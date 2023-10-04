using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

internal ref struct OperationParser
{
  internal Tokenizer _tokens;

  public OperationParser(Tokenizer tokens)
    => _tokens = tokens;

  internal OperationAst? Parse()
  {
    OperationAst ast = new();

    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return ast;
      }
    }

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
      return ast;
    }

    ast.Modifiers = ParseModifiers();
    ast.Fragments = ParseFragments();

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    }

    return ast;
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
      return false;
    }

    variables = result.ToArray();

    return _tokens.Take(')');
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
        return false;
      }
    }

    selections = fields.ToArray();
    return fields.Any();
  }

  internal bool ParseSelection(out AstSelection selection)
  {
    selection = AstNulls.Selection;

    if (_tokens.Take("...") || _tokens.Take('|')) {
      string? onType = null;
      if (_tokens.Take("on") || _tokens.Take(':')) {
        if (!_tokens.Identifier(out onType)) {
          return false;
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
        return false;
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

    if (_tokens.Prefix('$', out var variable)) {
      argument = new ArgumentAst(variable);
    }

    return _tokens.Take(")");
  }

  internal bool ParseArgValue(out ArgumentAst argument)
  {
    argument = new ArgumentAst();

    if (_tokens.Prefix('$', out var variable)) {
      argument = new ArgumentAst(variable);
      return true;
    }

    return false;
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

    if (ParseFieldKey(out var fieldKey)) {
      constant = fieldKey;
      return true;
    }

    var oldSeparators = _tokens.IgnoreSeparators;
    if (_tokens.Take('['))
      try {
        _tokens.IgnoreSeparators = false;

        var values = new List<ConstantAst>();
        while (!_tokens.Take(']')) {
          if (ParseConstant(out var item)) {
            values.Add(item);
          } else {
            return false;
          }
          _tokens.Take(',');
        }
        constant = new ConstantAst(values.ToArray());
        return true;
      } finally {
        _tokens.IgnoreSeparators = oldSeparators;
      }

    if (_tokens.Take('{'))
      try {
        _tokens.IgnoreSeparators = false;

        var fields = new ConstantAst.ObjectAst();

        while (!_tokens.Take('}')) {
          if (ParseFieldKey(out var key)
            && _tokens.Take(':')
            && ParseConstant(out var value)
          ) {
            fields.Add(key, value);
          } else {
            return false;
          }
          _tokens.Take(';');
        }
        constant = new ConstantAst(fields);
        return true;
      } finally {
        _tokens.IgnoreSeparators = oldSeparators;
      }

    return false;
  }
}
