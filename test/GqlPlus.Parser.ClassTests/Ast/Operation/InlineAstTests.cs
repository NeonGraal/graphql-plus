namespace GqlPlus.Ast.Operation;

public partial class InlineAstTests
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

  [CheckTests]
  internal IAstDirectivesChecks<string[]> DirectivesChecks => _checks;

  [CheckTests]
  internal ICloneChecks<string[]> CloneChecks { get; }
    = new CloneChecks<string[], InlineAst>(
      CreateInline,
      (original, input) => original with { Selections = input?.Fields() ?? [] });

  private static InlineAst CreateInline(string[] input)
    => new(AstNulls.At, input?.Fields() ?? []);
}

internal sealed class InlineAstChecks()
  : AstDirectivesChecks<string[], InlineAst>(CreateInline)
{
  protected override string DirectiveString(string[] input, string directives)
    => $"( !i{directives} {{ {input.Joined(s => "!f " + s)} }} )";

  internal static InlineAst CreateInline(string[] input, string[] directives)
    => new(AstNulls.At, input?.Fields() ?? []) { Directives = directives.Directives() };
}
