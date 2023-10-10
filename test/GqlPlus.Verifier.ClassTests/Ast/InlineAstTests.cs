namespace GqlPlus.Verifier.Ast;

public class InlineAstTests
{
  [Fact]
  public void HashCode()
    => new InlineAst().GetHashCode().Should().Be(new InlineAst().GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String(string field)
    => new InlineAst(field.Fields()).TestString($"I({{ F({field}) }})");

  [Theory, RepeatData(Repeats)]
  public void String_WithOnType(string onType, string field)
    => new InlineAst(field.Fields()) { OnType = onType }
    .TestString($"I(:{onType} {{ F({field}) }})");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string field, string directive)
    => new InlineAst(field.Fields()) { Directives = directive.Directives() }
    .TestString($"I(D({directive}) {{ F({field}) }})");

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
    if (field1 == field2) {
      return;
    }

    var left = new InlineAst(field1.Fields());
    var right = new InlineAst(field2.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOnType(string onType, string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields()) { OnType = onType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOnType(string onType, string field)
  {
    var left = new InlineAst(field.Fields()) { OnType = onType };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string field, string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string field, string directive)
  {
    var left = new InlineAst(field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(field.Fields());

    (left != right).Should().BeTrue();
  }
}
