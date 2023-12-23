namespace GqlPlus.Verifier.Ast;

public class NullAstTests
{
  [Fact]
  public void HashCode()
    => _checks.HashCode(() => new NullAst(AstNulls.At));

  [Fact]
  public void String()
    => _checks.String(() => new NullAst(AstNulls.At), "NULL");

  internal BaseAstChecks<NullAst> _checks = new();
}
