namespace GqlPlus.Ast;

public class NullAstTests
{
  [Fact]
  public void HashCode()
    => _checks.HashCode(() => new NullAst(AstNulls.At));

  [Fact]
  public void Text()
    => _checks.Text(() => new NullAst(AstNulls.At), "NULL");

  internal BaseAstChecks<NullAst> _checks = new();
}
