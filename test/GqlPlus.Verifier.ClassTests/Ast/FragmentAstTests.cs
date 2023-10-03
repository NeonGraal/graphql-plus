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
  public void WithName_Inequality(string name1, string name2, string onType, string field)
  {
    var left = new FragmentAst(name1, onType, field.Fields());
    var right = new FragmentAst(name2, onType, field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithOnType_Inequality(string name, string onType1, string onType2, string field)
  {
    var left = new FragmentAst(name, onType1, field.Fields());
    var right = new FragmentAst(name, onType2, field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithFields_Inequality(string name, string onType, string field1, string field2)
  {
    var left = new FragmentAst(name, onType, field1.Fields());
    var right = new FragmentAst(name, onType, field2.Fields());

    (left != right).Should().BeTrue();
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
