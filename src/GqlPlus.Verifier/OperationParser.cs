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

    if (operation.At('(')) {
      _ = operation.Take('(');

      ast.Variables = ParseVariables(operation);
    }

    if (operation.At('@')) {
      ast.Directives = ParseDirectives(operation);
    }

    if (operation.At('{')) {
      ast.ResultObject = ParseObject(operation);
    } else if (operation.AtIdentifier) {
      ast.ResultType = operation.TakeIdentifier();
    }

    if (operation.At('[', '?')) {
      ast.Modifiers = ParseModifiers(operation);
    }

    if (operation.AtIdentifier) {
      if (operation.TakeIdentifier() == "fragment") {
        ast.Definitions = ParseDefinitions(operation);
      }
    }

    if (operation.AtEnd) {
      ast.Result = ParseResult.Success;
    }

    return ast;
  }

  private static DirectiveAst[] ParseDirectives(OperationTokens operation) => throw new NotImplementedException();

  private static VariableAst[] ParseVariables(OperationTokens operation) => throw new NotImplementedException();

  private static ObjectAst ParseObject(OperationTokens operation) => throw new NotImplementedException();

  private static ModifierAst[] ParseModifiers(OperationTokens operation) => throw new NotImplementedException();

  private static DefinitionAst[] ParseDefinitions(OperationTokens operation) => throw new NotImplementedException();
}
