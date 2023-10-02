namespace GqlPlus.Verifier.Ast;

public class FragmentAstTests
{
  [Theory, RepeatData(Repeats)]
  public void Equality(string name, string onType, string field)
  {
    var left = new FragmentAst(name, onType, field.Fields());
    var right = new FragmentAst(name, onType, field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Equality(string name, string onType, string field, string directive)
  {
    var left = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Inequality(string name, string onType, string field, string directive)
  {
    var left = new FragmentAst(name, onType, field.Fields()) { Directives = directive.Directives() };
    var right = new FragmentAst(name, onType, field.Fields());

    (left != right).Should().BeTrue();
  }
}
