namespace GqlPlus.Ast.Operation;

public partial class InlineAstTests
{
  [Theory, RepeatData]
  public void HashCode_WithOnType(string onType)
    => _checks.HashCode(() => new InlineAst(AstNulls.At, onType));

  [Theory, RepeatData]
  public void Text_WithOnType(string onType)
    => _checks.Text(
      () => new InlineAst(AstNulls.At, onType),
      $"( !i :{onType} )");

  [Theory, RepeatData]
  public void Equality_WithOnType(string onType)
    => _checks.Equality(
      () => new InlineAst(AstNulls.At, onType));

  [Theory, RepeatData]
  public void Inequality_WithOnType(string onType)
    => _checks.InequalityWith(null,
      () => new InlineAst(AstNulls.At, onType));

  private readonly InlineAstChecks _checks = new();

  [CheckTests]
  internal IAstDirectivesChecks<string?> DirectivesChecks => _checks;

  [CheckTests]
  internal IModifiersChecks<string?> ModifiersChecks { get; } = new InlineModifiersChecks();

  [CheckTests]
  internal ICloneChecks<string?> CloneChecks { get; }
    = new CloneChecks<string?, InlineAst>(
      CreateInline,
      (original, input) => original with { OnType = input });

  internal static InlineAst CreateInline(string? input)
    => new(AstNulls.At, input);
}

internal sealed class InlineModifiersChecks()
  : ModifiersChecks<string?, InlineAst>(
      InlineAstTests.CreateInline,
      ast => ast with { Modifiers = TestMods() })
{
  protected override string InputString(string? input)
    => input.IsWhiteSpace() ? $"( !i )" : $"( !i :{input} )";
}

internal sealed class InlineAstChecks()
  : AstDirectivesChecks<string?, InlineAst>(CreateInline)
{
  protected override string DirectiveString(string? input, string directives)
    => input.IsWhiteSpace() ? $"( !i{directives} )" : $"( !i :{input}{directives} )";

  internal static InlineAst CreateInline(string? input, string[] directives)
    => new(AstNulls.At, input) {
      Directives = directives.Directives()
    };
}
