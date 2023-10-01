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
    } else if (ParseObject(out SelectionAst[] selections)) {
      ast.ResultObject = selections;
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
        modifier = new() {
          Key = key,
          KeyOptional = _tokens.Take('?')
        };
      } else {
        if (_tokens.TakeAny(out var charType, '~', '0', '*')) {
          modifier = new() {
            Key = charType.ToString(),
            KeyOptional = _tokens.Take('?')
          };
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

  internal bool ParseObject(out SelectionAst[] selections)
  {
    selections = Array.Empty<SelectionAst>();
    if (!_tokens.Take('{')) {
      return false;
    }

    var fields = new List<SelectionAst>();

    while (!_tokens.Take('}')) {
      if (ParseSelection(out SelectionAst fragment)) {
        fields.Add(fragment);
      } else if (ParseField(out SelectionAst field)) {
        fields.Add(field);
      } else {
        selections = fields.ToArray();
        return false;
      }
    }

    selections = fields.ToArray();
    return fields.Any();
  }

  internal bool ParseSelection(out SelectionAst selection)
  {
    selection = NullAst.Selection;

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

      if (ParseObject(out SelectionAst[] selections)) {
        selection = new InlineAst(selections) {
          OnType = onType,
          Directives = directives,
        };
        return true;
      }
    }

    return false;
  }

  internal bool ParseField(out SelectionAst field)
  {
    field = NullAst.Selection;

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

    if (ParseObject(out SelectionAst[] selections)) {
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
        if (ParseObject(out SelectionAst[] selections)) {
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

  internal bool ParseConstant(out ConstantAst constant)
  {
    constant = new ConstantAst();

    if (_tokens.Number(out var number)) {
      constant = new ConstantAst(number);
      return true;
    }

    if (_tokens.String(out var contents)) {
      constant = new ConstantAst(contents);
      return true;
    }

    if (_tokens.Identifier(out var identifier)) {
      if (_tokens.Take('.') && _tokens.Identifier(out var label)) {
        constant = new ConstantAst(identifier, label);
        return true;
      }
      constant = new ConstantAst("", identifier);
      return true;
    }

    return false;
  }
}
