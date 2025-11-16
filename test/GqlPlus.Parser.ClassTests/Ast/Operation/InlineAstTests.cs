namespace GqlPlus.Ast.Operation;

public class InlineAstTests
  : AstDirectivesBaseTests<string[]>
{
  [Theory, RepeatData]
  public void HashCode_WithOnType(string onType, string[] fields)
    => _checks.HashCode(() => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData]
  public void Text_WithOnType(string onType, string[] fields)
    => _checks.Text(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType },
      $"( !i :{onType} {{ {fields.Joined(s => "!f " + s)} }} )");

  [Theory, RepeatData]
  public void Equality_WithOnType(string onType, string[] fields)
    => _checks.Equality(
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  [Theory, RepeatData]
  public void Inequality_WithOnType(string onType, string[] fields)
    => _checks.InequalityWith(fields,
      () => new InlineAst(AstNulls.At, fields.Fields()) { OnType = onType });

  private readonly InlineAstChecks _checks = new();

  internal override IAstDirectivesChecks<string[]> DirectivesChecks => _checks;

  protected override bool InputEquals(string[]? input1, string[]? input2)
    => input1 is null ? input2 is null : input2 is not null && input1.SequenceEqual(input2);
}

internal sealed class InlineAstChecks()
  : AstDirectivesChecks<string[], InlineAst>(CreateInline)
{
  protected override string DirectiveString(string[] input, string directives)
    => $"( !i{directives} {{ {input.Joined(s => "!f " + s)} }} )";

  private static InlineAst CreateInline(string[] input, string[] directives)
    => new(AstNulls.At, input?.Fields() ?? []) { Directives = directives.Directives() };
  private static InlineAst CloneInline(InlineAst original, string[] input)
    => original with { Selections = input?.Fields() ?? [] };
}
