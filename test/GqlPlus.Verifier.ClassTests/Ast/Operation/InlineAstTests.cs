namespace GqlPlus.Verifier.Ast.Operation;

public class InlineAstTests : AstDirectivesTests<string[]>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithOnType(string onType, string[] fields)
    => _checks.HashCode(() => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData(Repeats)]
  public void String_WithOnType(string onType, string[] fields)
    => _checks.Text(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType },
      $"( !i :{onType} {{ {fields.Joined("!f ")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithOnType(string onType, string[] fields)
    => _checks.Equality(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithOnType(string onType, string[] fields)
    => _checks.InequalityWith(fields,
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  private readonly AstDirectivesChecks<string[], InlineAst> _checks
    = new(input => new InlineAst(AstNulls.At, input?.Fields() ?? Array.Empty<IAstSelection>()));

  internal override IAstDirectivesChecks<string[]> DirectivesChecks => _checks;

  protected override string DirectiveString(string[] input, string directives)
    => $"( !i{directives} {{ {input.Joined("!f ")} }} )";
}
