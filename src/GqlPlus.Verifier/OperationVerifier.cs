using System.Reflection.Metadata.Ecma335;

namespace GqlPlus.Verifier;

public class OperationVerifier
{
  public static bool Verify(string operation)
  {
    var ast = OperationParser.Parse(operation);

    return ast == null ? false : Verify(ast);
  }

  private static bool Verify(OperationAst ast)
  {
    return ast.Result == ParseResult.Success;
  }
}
