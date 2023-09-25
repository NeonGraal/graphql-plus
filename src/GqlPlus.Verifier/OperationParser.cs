namespace GqlPlus.Verifier;

internal class OperationParser
{
  internal static OperationAst? Parse(OperationTokens operation)
  {
    var ast = new OperationAst();

    if (operation.AtStart) {
      if (!operation.Read()) {
        return ast;
      }
    }

    if (operation.AtIdentifier) {
      ast.Category = operation.TakeIdentifier();

      if (operation.AtIdentifier) {
        ast.Name = operation.TakeIdentifier();
      }
    }

    if (operation.Take('(')) {
      ast.Variables = ParseVariables(ref operation);
    }

    if (operation.At('@')) {
      ast.Directives = ParseDirectives(ref operation);
    }

    if (operation.At('{')) {
      ast.ResultObject = ParseObject(ref operation);
      if (ast.ResultObject is null or { Length: 0 }) {
        return ast;
      }
    } else if (operation.AtIdentifier) {
      ast.ResultType = operation.TakeIdentifier();
    }

    if (operation.At('[', '?')) {
      ast.Modifiers = ParseModifiers(ref operation);
    }

    if (operation.AtIdentifier) {
      if (operation.TakeIdentifier() == "fragment") {
        ast.Definitions = ParseDefinitions(ref operation);
      }
    }

    if (operation.AtEnd) {
      ast.Result = ParseResult.Success;
    }

    return ast;
  }

  private static DirectiveAst[] ParseDirectives(ref OperationTokens operation) => throw new NotImplementedException();

  private static VariableAst[] ParseVariables(ref OperationTokens operation) => throw new NotImplementedException();

  private static SelectionAst[]? ParseObject(ref OperationTokens operation)
  {
    if (!operation.Take('{')) {
      return null;
    }

    var fields = new List<SelectionAst>();

    while (operation.At("...") || operation.AtIdentifier) {
      SelectionAst? field = null;
      if (operation.AtIdentifier) {
        field = ParseField(ref operation);
      } else {
        field = ParseFragment(ref operation);
      }
      if (field != null) {
        fields.Add(field);
      }
    }

    if (!operation.Take('}')) {
      return null;
    }

    ;

    return fields.ToArray();
  }

  private static FragmentAst? ParseFragment(ref OperationTokens operation) => throw new NotImplementedException();
  private static FieldAst? ParseField(ref OperationTokens operation)
  {
    var name = operation.TakeIdentifier();

    FieldAst? field = null;

    if (operation.At(':')) {
      operation.Take(':');
      if (!operation.AtIdentifier) {
        return null;
      }
      field = new FieldAst(operation.TakeIdentifier()) { Alias = name };
    } else {
      field = new FieldAst(name);
    }

    return field;
  }

  private static ModifierAst[] ParseModifiers(ref OperationTokens operation)
  {
    var modifiers = new List<ModifierAst>();

    while (operation.Take('[')) {
      if (operation.AtIdentifier) {
        var key = operation.TakeIdentifier();
        modifiers.Add(new(ModifierKind.Dict) {
          Key = key,
          KeyOptional = operation.Take('?')
        });
      } else {
        modifiers.Add(new(ModifierKind.List));
      }
      if (!operation.Take(']')) {
        return Array.Empty<ModifierAst>();
      }
    }

    if (operation.Take('?')) {
      modifiers.Add(new(ModifierKind.Optional));
    }

    return modifiers.ToArray();
  }

  private static DefinitionAst[] ParseDefinitions(ref OperationTokens operation) => throw new NotImplementedException();
}
