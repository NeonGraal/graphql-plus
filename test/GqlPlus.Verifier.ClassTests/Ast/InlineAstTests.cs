namespace GqlPlus.Verifier.Ast;

public class InlineAstTests
{
  [Fact]
  public void HashCode()
    => new InlineAst(AstNulls.At).GetHashCode().Should().Be(new InlineAst(AstNulls.At).GetHashCode());

  [Theory, RepeatData(Repeats)]
  public void String(string field)
    => new InlineAst(AstNulls.At, field.Fields()).TestString($"I({{ F({field}) }})");

  [Theory, RepeatData(Repeats)]
  public void String_WithOnType(string onType, string field)
    => new InlineAst(AstNulls.At, field.Fields()) { OnType = onType }
    .TestString($"I(:{onType} {{ F({field}) }})");

  [Theory, RepeatData(Repeats)]
  public void String_WithDirective(string field, string directive)
    => new InlineAst(AstNulls.At, field.Fields()) { Directives = directive.Directives() }
    .TestString($"I(D({directive}) {{ F({field}) }})");

  [Theory, RepeatData(Repeats)]
  public void Equality(string field)
  {
    var left = new InlineAst(AstNulls.At, field.Fields());
    var right = new InlineAst(AstNulls.At, field.Fields());

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality(string field1, string field2)
  {
    if (field1 == field2) {
      return;
    }

    var left = new InlineAst(AstNulls.At, field1.Fields());
    var right = new InlineAst(AstNulls.At, field2.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOnType(string onType, string field)
  {
    var left = new InlineAst(AstNulls.At, field.Fields()) { OnType = onType };
    var right = new InlineAst(AstNulls.At, field.Fields()) { OnType = onType };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOnType(string onType, string field)
  {
    var left = new InlineAst(AstNulls.At, field.Fields()) { OnType = onType };
    var right = new InlineAst(AstNulls.At, field.Fields());

    (left != right).Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDirective(string field, string directive)
  {
    var left = new InlineAst(AstNulls.At, field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(AstNulls.At, field.Fields()) { Directives = directive.Directives() };

    (left == right).Should().BeTrue();

    left.Should().NotBeSameAs(right);
  }

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDirective(string field, string directive)
  {
    var left = new InlineAst(AstNulls.At, field.Fields()) { Directives = directive.Directives() };
    var right = new InlineAst(AstNulls.At, field.Fields());

    (left != right).Should().BeTrue();
  }
}
