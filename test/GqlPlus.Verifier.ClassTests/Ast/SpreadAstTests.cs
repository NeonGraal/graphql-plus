namespace GqlPlus.Verifier.Ast;

public class SpreadAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String(string name)
    => new SpreadAst(name).TestString($"S({name})");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string name, string directive)
    => new SpreadAst(name) { Directives = directive.Directives() }
    .TestString($"S({name} D({directive}))");

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
  public void Equality_WithDirective(string name, string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string name, string directive)
  {
    var left = new SpreadAst(name) { Directives = directive.Directives() };
    var right = new SpreadAst(name);

    (left != right).Should().BeTrue();
  }
}
