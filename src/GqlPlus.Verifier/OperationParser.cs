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

    if (_tokens.Take('(')) {
      ast.Variables = ParseVariables();
    }

    if (_tokens.At('@')) {
      ast.Directives = ParseDirectives();
    }

    if (_tokens.At('{')) {
      if (!ParseObject(out var selections)) {
        return ast;
      }

      ast.ResultObject = selections;
    } else if (_tokens.TakeIdentifier(out var result)) {
      ast.ResultType = result;
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

      directives.Add(directive);
    }

    return directives.ToArray();
  }

  internal VariableAst[] ParseVariables()
  {
    if (!_tokens.Take('(')) {
      return Array.Empty<VariableAst>();
    }

    var variables = new List<VariableAst>();

    while (_tokens.Prefix('$', out var name)) {
      var variable = new VariableAst(name);

      variables.Add(variable);
    }

    return _tokens.Take(')')
      ? variables.ToArray()
      : Array.Empty<VariableAst>();
  }

  internal bool ParseObject(out SelectionAst[] selections)
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

    if (_tokens.Take("...")) {
      string? onType = null;
      if (_tokens.Take("on")) {
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
        if (ParseObject(out var selections)) {
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
    if (_tokens.TakeIdentifier(out var alias)) {
      if (_tokens.Take(':')) {
        if (_tokens.TakeIdentifier(out var name)) {
          field = new FieldAst(name) { Alias = alias };
          return true;
        }
      } else {
        field = new FieldAst(alias);
        return true;
      }
    }

    field = NullAst.Selection;
    return false;
  }

  internal ModifierAst[] ParseModifiers()
  {
    var modifiers = new List<ModifierAst>();

    while (_tokens.Take('[')) {
      if (_tokens.TakeIdentifier(out var key)) {
        modifiers.Add(new(ModifierKind.Dict) {
          Key = key,
          KeyOptional = _tokens.Take('?')
        });
      } else {
        if (_tokens.TakeAny(out var charType, '~', '0', '*')) {
          modifiers.Add(new(ModifierKind.Dict) {
            Key = charType.ToString(),
            KeyOptional = _tokens.Take('?')
          });
        } else {
          modifiers.Add(new(ModifierKind.List));
        }
      }

      if (!_tokens.Take(']')) {
        return Array.Empty<ModifierAst>();
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

    while (_tokens.Take("fragment")) {
      if (_tokens.TakeIdentifier(out var name) &&
        _tokens.Take("on") &&
        _tokens.TakeIdentifier(out var onType)
      ) {
        if (ParseObject(out var selections)) {
          var fragment = new DefinitionAst(name, onType) {
            Selections = selections,
          };
          definitions.Add(fragment);
        }
      }
    }

    return definitions.ToArray();
  }
}
