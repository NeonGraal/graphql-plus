namespace GqlPlus.Ast.Operation;

public partial class OpInlineAstTests
{
  [Theory, RepeatData]
  public void HashCode_WithOnType(string onType)
    => _checks.HashCode(() => new OpInlineAst(AstNulls.At, onType));

  [Theory, RepeatData]
  public void Text_WithOnType(string onType)
    => _checks.Text(() => new OpInlineAst(AstNulls.At, onType),
      $"( !oi :{onType} )");

  [Theory, RepeatData]
  public void Equality_WithOnType(string onType)
    => _checks.Equality(
      () => new OpInlineAst(AstNulls.At, onType));

  [Theory, RepeatData]
  public void Inequality_WithOnType(string onType)
    => _checks.InequalityWith(onType,
      () => new OpInlineAst(AstNulls.At, null));

  private readonly OpInlineAstChecks _checks = new();

  [CheckTests]
  internal IAstDirectivesChecks<string?> DirectivesChecks => _checks;

  [CheckTests]
  internal IModifiersChecks<string?> ModifiersChecks { get; } = new OpInlineModifiersChecks();

  [CheckTests]
  internal ICloneChecks<string?> CloneChecks { get; }
    = new CloneChecks<string?, OpInlineAst>(
      CreateInline,
      (original, input) => original with { OnType = input });

  internal static OpInlineAst CreateInline(string? input)
    => new(AstNulls.At, input);
}

internal sealed class OpInlineModifiersChecks()
  : ModifiersChecks<string?, OpInlineAst>(
      OpInlineAstTests.CreateInline,
      ast => ast with { Modifiers = TestMods() })
{
  protected override string InputString(string? input)
    => input.IsWhiteSpace() ? $"( !oi )" : $"( !oi :{input} )";
}

internal sealed class OpInlineAstChecks()
  : AstDirectivesChecks<string?, OpInlineAst>(CreateInline)
{
  protected override string DirectiveString(string? input, string directives)
    => input.IsWhiteSpace() ? $"( !oi{directives} )" : $"( !oi :{input}{directives} )";

  internal static OpInlineAst CreateInline(string? input, string[] directives)
    => new(AstNulls.At, input) { Directives = directives.Directives() };
}
