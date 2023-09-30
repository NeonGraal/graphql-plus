using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

public class OperationVerifier
{
  public static bool Verify(string operation)
  {
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    OperationAst? ast = parser.Parse();

    return ast != null && Verify(ast);
  }

  private static bool Verify(OperationAst ast) => ast.Result == ParseResult.Success;
}
