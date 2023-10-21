namespace GqlPlus.Verifier.Ast.Operation;

public class InlineAstTests : BaseNamedDirectivesAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOnType(string onType, string field)
    => _checks.HashCode(() => new InlineAst(AstNulls.At, field.Fields()) { OnType = onType });

  [Theory, RepeatData(Repeats)]
  public void String_WithOnType(string onType, string field)
    => _checks.String(
      () => new InlineAst(AstNulls.At, field.Fields()) { OnType = onType },
      $"( !i :{onType} {{ ( !f {field} ) }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOnType(string onType, string field)
    => _checks.Equality(
      () => new InlineAst(AstNulls.At, field.Fields()) { OnType = onType });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOnType(string onType, string field)
    => _checks.InequalityWith(field,
      () => new InlineAst(AstNulls.At, field.Fields()) { OnType = onType });

  private readonly BaseNamedDirectivesAstChecks<InlineAst> _checks
    = new(name => new InlineAst(AstNulls.At, name.Fields()));

  internal override IBaseNamedDirectivesAstChecks DirectivesChecks => _checks;

  protected override string ExpectedString(string input)
    => $"( !i {{ ( !f {input} ) }} )";

  protected override string ExpectedString(string input, string directive)
    => $"( !i ( !d {directive} ) {{ ( !f {input} ) }} )";
}
