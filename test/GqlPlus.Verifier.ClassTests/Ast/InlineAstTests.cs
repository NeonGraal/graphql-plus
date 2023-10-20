namespace GqlPlus.Verifier.Ast;

public class InlineAstTests : BaseNamedDirectivesAstTests
{
  [Theory, RepeatData(Repeats)]
  public void String_WithOnType(string onType, string field)
    => new InlineAst(AstNulls.At, field.Fields()) { OnType = onType }
    .TestString($"( !I :{onType} {{ ( !F {field} ) }} )");

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

  internal override BaseNamedDirectivesAstChecks DirectivesChecks { get; }
    = new BaseNamedDirectivesAstChecks<InlineAst>(name => new InlineAst(AstNulls.At, name.Fields()));

  protected override string ExpectedString(string name)
    => $"( !I {{ ( !F {name} ) }} )";

  protected override string ExpectedString(string name, string directive)
    => $"( !I ( !D {directive} ) {{ ( !F {name} ) }} )";
}
