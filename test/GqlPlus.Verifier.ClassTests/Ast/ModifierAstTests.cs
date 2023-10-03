namespace GqlPlus.Verifier.Ast;

public class ModifierAstTests
{
  [Fact]
  public void Inequality()
  {
    var left = ModifierAst.Optional;
    var right = ModifierAst.List;

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithKey_Equality(string key, bool optional)
  {
    var left = new ModifierAst(key, optional);
    var right = new ModifierAst(key, optional);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithKey_Inequality(string key, bool optional)
  {
    var left = new ModifierAst(key, optional);
    var right = ModifierAst.List;

    (left != right).Should().BeTrue();
  }
}
