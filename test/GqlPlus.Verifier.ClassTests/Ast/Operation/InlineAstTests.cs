namespace GqlPlus.Verifier.Ast.Operation;

public class InlineAstTests : BaseDirectivesAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOnType(string onType, string[] fields)
    => _checks.HashCode(() => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData(Repeats)]
  public void String_WithOnType(string onType, string[] fields)
    => _checks.String(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType },
      $"( !i :{onType} {{ {fields.Joined("!f ")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOnType(string onType, string[] fields)
    => _checks.Equality(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOnType(string onType, string[] fields)
    => _checks.InequalityWith(fields[0],
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  private readonly BaseDirectivesAstChecks<InlineAst> _checks
    = new(name => new InlineAst(AstNulls.At, new[] { name }.Fields()));

  internal override IBaseDirectivesAstChecks DirectivesChecks => _checks;

  protected override string InputString(string input)
    => $"( !i {{ !f {input} }} )";

  protected override string DirectiveString(string input, string[] directives)
    => $"( !i {directives.Joined(d => $"( !d {d} )")} {{ !f {input} }} )";
}
