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

    var category = _tokens.TakeIdentifier();

    if (category is not null) {
      if (_tokens.AtIdentifier) {
        ast = new(_tokens.TakeIdentifier()!) { Category = category };
      } else {
        ast.Category = category;
      }
    }

    if (_tokens.Take('(') == '(') {
      ast.Variables = ParseVariables();
    }

    if (_tokens.At('@')) {
      ast.Directives = ParseDirectives();
    }

    if (_tokens.At('{')) {
      ast.ResultObject = ParseObject();
      if (ast.ResultObject is null or { Length: 0 }) {
        return ast;
      }
    } else if (_tokens.AtIdentifier) {
      ast.ResultType = _tokens.TakeIdentifier();
    }

    if (_tokens.At('[', '?')) {
      ast.Modifiers = ParseModifiers();
    }

    if (_tokens.AtIdentifier) {
      if (_tokens.TakeIdentifier() == "fragment") {
        ast.Definitions = ParseDefinitions();
      }
    }

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    }

    return ast;
  }

  internal DirectiveAst[] ParseDirectives()
  {
    var directives = new List<DirectiveAst>();

    while(_tokens.Prefix('@')is not null) {
      var directive = new DirectiveAst(_tokens.TakeIdentifier()!);

      directives.Add(directive);
    }

    return directives.ToArray();
  }

  internal VariableAst[] ParseVariables()
  {
    if (_tokens.Take('(') is null) {
      return Array.Empty<VariableAst>();
    }

    var variables = new List<VariableAst>();

    while(_tokens.Prefix('$') is not null) {
      var variable = new VariableAst(_tokens.TakeIdentifier()!);

      variables.Add(variable);
    }

    return _tokens.Take(')') is null
      ? Array.Empty<VariableAst>()
      : variables.ToArray();
  }

  internal SelectionAst[]? ParseObject()
  {
    if (_tokens.Take('{') is null) {
      return null;
    }

    var fields = new List<SelectionAst>();

    while (_tokens.At("...") || _tokens.AtIdentifier) {
      SelectionAst? field = _tokens.AtIdentifier
        ? ParseField()
        : ParseFragment();

      if (field != null) {
        fields.Add(field);
      }
    }

    return _tokens.Take('}') is null ? null : fields.ToArray();
  }

  internal FragmentAst? ParseFragment() => throw new NotImplementedException();

  internal FieldAst? ParseField()
  {
    var name = _tokens.TakeIdentifier();

    if (name is null) {
      return null;
    }

    FieldAst? field;
    if (_tokens.Take(':') == ':') {
      if (!_tokens.AtIdentifier) {
        return null;
      }

      field = new FieldAst(_tokens.TakeIdentifier()!) { Alias = name };
    } else {
      field = new FieldAst(name);
    }

    return field;
  }

  internal ModifierAst[] ParseModifiers()
  {
    var modifiers = new List<ModifierAst>();

    while (_tokens.Take('[') == '[') {
      if (_tokens.AtIdentifier) {
        var key = _tokens.TakeIdentifier();
        modifiers.Add(new(ModifierKind.Dict) {
          Key = key,
          KeyOptional = _tokens.Take('?') == '?'
        });
      } else {
        var key = _tokens.Take('~', '0', '*');
        if (key is null) {
          modifiers.Add(new(ModifierKind.List));
        } else {
          modifiers.Add(new(ModifierKind.Dict) {
            Key = key.ToString(),
            KeyOptional = _tokens.Take('?') == '?'
          });
        }
      }

      if (_tokens.Take(']') is null) {
        return Array.Empty<ModifierAst>();
      }
    }

    if (_tokens.Take('?') == '?') {
      modifiers.Add(new(ModifierKind.Optional));
    }

    return modifiers.ToArray();
  }

  internal DefinitionAst[] ParseDefinitions() => throw new NotImplementedException();
}
