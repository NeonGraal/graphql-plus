namespace GqlPlus.Verifier.Ast;

public class InlineAstTests
{
  [Theory, RepeatData(Repeats)]
  public void Equality(string field)
  {
    var left = new InlineAst(field.Fields());
    var right = new InlineAst(field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string field1, string field2)
  {
    var left = new InlineAst(field1.Fields());
    var right = new InlineAst(field2.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithOnType_Equality(string onType, string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields()) { OnType = onType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithOnType_Inequality(string onType, string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Equality(string field, string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_Inequality(string field, string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }
}
