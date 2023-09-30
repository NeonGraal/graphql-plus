using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

internal ref struct OperationParser
{
  internal OperationTokens _tokens;

  public OperationParser(OperationTokens tokens) => _tokens = tokens;

  internal OperationAst? Parse()
  {
    OperationAst ast = new();

    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return ast;
      }
    }

    if (_tokens.TakeIdentifier(out var category)) {
      if (_tokens.TakeIdentifier(out var name)) {
        ast = new(name) { Category = category };
      } else {
        ast.Category = category;
      }
    }

    if (ParseVariables(out VariableAst[] variables)) {
      ast.Variables = variables;
    }

    if (_tokens.At('@')) {
      ast.Directives = ParseDirectives();
    }

    if (_tokens.Prefix(':', out var result)) {
      ast.ResultType = result;
    } else if (ParseSelections(out SelectionAst[] selections)) {
      ast.ResultObject = selections;
    } else {
      return ast;
    }

    if (_tokens.At('[', '?')) {
      ast.Modifiers = ParseModifiers();
    }

    if (_tokens.At("fragment")) {
      ast.Definitions = ParseDefinitions();
    }

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    }

    return ast;
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

  internal bool ParseVariables(out VariableAst[] variables)
  {
    variables = Array.Empty<VariableAst>();
    if (!_tokens.Take('(')) {
      return false;
    }

    var result = new List<VariableAst>();

    while (_tokens.Prefix('$', out var name)) {
      var variable = new VariableAst(name);

      result.Add(variable);
    }

    if (!result.Any()) {
      return false;
    }

    variables = result.ToArray();

    return _tokens.Take(')');
  }

  internal bool ParseSelections(out SelectionAst[] selections)
  {
    selections = Array.Empty<SelectionAst>();
    if (!_tokens.Take('{')) {
      return false;
    }

    var fields = new List<SelectionAst>();

    while (_tokens.At("...") || _tokens.AtIdentifier) {
      if (_tokens.AtIdentifier) {
        if (ParseField(out SelectionAst field)) {
          fields.Add(field);
        }
      } else if (ParseFragment(out SelectionAst fragment)) {
        fields.Add(fragment);
      }
    }

    if (!fields.Any()) {
      return false;
    }

    selections = fields.ToArray();
    return _tokens.Take('}');
  }

  internal bool ParseFragment(out SelectionAst fragment)
  {
    fragment = NullAst.Selection;

    if (_tokens.Take("...") || _tokens.Take('|')) {
      string? onType = null;
      if (_tokens.Take("on") || _tokens.Take(':')) {
        if (!_tokens.TakeIdentifier(out onType)) {
          return false;
        }
      } else {
        if (_tokens.TakeIdentifier(out var name)) {
          fragment = new SpreadAst(name);
          return true;
        }
      }

      if (_tokens.At('{')) {
        if (ParseSelections(out SelectionAst[] selections)) {
          fragment = new InlineAst {
            OnType = onType,
            Selections = selections
          };
          return true;
        }
      }
    }

    return false;
  }

  internal bool ParseField(out SelectionAst field)
  {
    field = NullAst.Selection;

    if (!_tokens.TakeIdentifier(out var alias)) {
      return false;
    }

    var result = new FieldAst(alias);

    if (_tokens.Take(':')) {
      if (!_tokens.TakeIdentifier(out var name)) {
        return false;
      }

      result = new FieldAst(name) { Alias = alias };
    }

    if (ParseArgument(out ArgumentAst argument)) {
      result.Argument = argument;
    }

    if (ParseSelections(out SelectionAst[] selections)) {
      result.Selections = selections;
    }

    field = result;
    return true;
  }

  internal ModifierAst[] ParseModifiers()
  {
    var modifiers = new List<ModifierAst>();

    while (_tokens.Take('[')) {
      ModifierAst modifier = new(ModifierKind.List);

      if (_tokens.TakeIdentifier(out var key)) {
        modifier = new(ModifierKind.Dict) {
          Key = key,
          KeyOptional = _tokens.Take('?')
        };
      } else {
        if (_tokens.TakeAny(out var charType, '~', '0', '*')) {
          modifier = new(ModifierKind.Dict) {
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
      modifiers.Add(new(ModifierKind.Optional));
    }

    return modifiers.ToArray();
  }

  internal DefinitionAst[] ParseDefinitions()
  {
    var definitions = new List<DefinitionAst>();

    while (_tokens.Take("fragment") || _tokens.Take('&')) {
      if (_tokens.TakeIdentifier(out var name) &&
        (_tokens.Take("on") || _tokens.Take(':')) &&
        _tokens.TakeIdentifier(out var onType)
      ) {
        if (ParseSelections(out SelectionAst[] selections)) {
          var fragment = new DefinitionAst(name, onType) {
            Selections = selections,
          };
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
      argument.Variable = variable;
    }

    return _tokens.Take(")");
  }
}
