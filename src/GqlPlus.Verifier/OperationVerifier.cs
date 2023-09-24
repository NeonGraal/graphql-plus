namespace GqlPlus.Verifier;

public class OperationVerifier
{
  public static bool Verify(string operation)
  {
    var tokenizer = new OperationTokens(operation);
    OperationAst? ast = OperationParser.Parse(tokenizer);

    return ast != null && Verify(ast);
  }

  private static bool Verify(OperationAst ast) => ast.Result == ParseResult.Success;
}
