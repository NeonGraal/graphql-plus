namespace GqlPlus.Ast;

public class NullAstTests
{
  [Fact]
  public void HashCode_Default_ReturnsExpectedValue()
    => _checks.HashCode(() => new NullAst(AstNulls.At));

  [Fact]
  public void Text_Default_ReturnsNullText()
    => _checks.Text(() => new NullAst(AstNulls.At), "NULL");

  internal BaseAstChecks<NullAst> _checks = new();
}
