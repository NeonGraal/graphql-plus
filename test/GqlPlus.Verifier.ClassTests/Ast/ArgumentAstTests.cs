namespace GqlPlus.Verifier.Ast;

public class ArgumentAstTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_Equality(string variable)
  {
    var left = new ArgumentAst(variable);
    var right = new ArgumentAst(variable);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }
}
