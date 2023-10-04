namespace GqlPlus.Verifier.Ast;

public class SpreadAstTests
{
  [Theory, RepeatData(Repeats)]
  public void Equality(string name)
  {
    var left = new SpreadAst(name);
    var right = new SpreadAst(name);

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    var left = new SpreadAst(name1);
    var right = new SpreadAst(name2);

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Equality(string name, string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Inequality(string name, string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name);

    (left != right).Should().BeTrue();
  }
}
