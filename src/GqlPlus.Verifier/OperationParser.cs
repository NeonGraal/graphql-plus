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
      ast.ResultObject = ParseObject();
      if (ast.ResultObject is null or { Length: 0 }) {
        return ast;
      }
    } else if (_tokens.TakeIdentifier(out var result)) {
      ast.ResultType = result;
    }

    if (_tokens.At('[', '?')) {
      ast.Modifiers = ParseModifiers();
    }

    if (_tokens.Take("fragment")) {
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

  internal SelectionAst[]? ParseObject()
  {
    if (!_tokens.Take('{')) {
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
    return _tokens.Take('}') ? fields.ToArray() : null;
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
    if (_tokens.TakeIdentifier() is string alias) {
    if (_tokens.TakeIdentifier(out var alias)) {
      if (_tokens.Take(':')) {
        if (_tokens.TakeIdentifier() is string name) {
        if (_tokens.TakeIdentifier(out var name)) {
          return new FieldAst(name) { Alias = alias };
        }
      } else {
        return new FieldAst(alias);
      }

      field = new FieldAst(_tokens.TakeIdentifier()!) { Alias = name };
    } else {
      field = new FieldAst(name);
    }

    return field;
    return null;
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

  internal DefinitionAst[] ParseDefinitions() => throw new NotImplementedException();
}
