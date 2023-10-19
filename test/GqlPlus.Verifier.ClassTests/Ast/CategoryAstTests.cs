namespace GqlPlus.Verifier.Ast;

public class CategoryAstTests
{
  [Fact]
  public void HashCode()
    => new CategoryAst(AstNulls.At, "").GetHashCode().Should().Be(new CategoryAst(AstNulls.At, "").GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String(string name)
    => new CategoryAst(AstNulls.At, name).TestString($"( !c {name} (Parallel) )");

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(string name, string alias)
    => new CategoryAst(AstNulls.At, name) { Aliases = new[] { alias } }
    .TestString($"( !c {name} [ {alias} ] (Parallel) )");

  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new CategoryAst(AstNulls.At, name);
    var right = new CategoryAst(AstNulls.At, name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    var left = new CategoryAst(AstNulls.At, name1);
    var right = new CategoryAst(AstNulls.At, name2);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(string name, string alias)
  {
    var left = new CategoryAst(AstNulls.At, name) { Aliases = new[] { alias } };
    var right = new CategoryAst(AstNulls.At, name) { Aliases = new[] { alias } };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAlias(string name, string alias)
  {
    var left = new CategoryAst(AstNulls.At, name) { Aliases = new[] { alias } };
    var right = new CategoryAst(AstNulls.At, name);

    (left != right).Should().BeTrue();
  }
}
