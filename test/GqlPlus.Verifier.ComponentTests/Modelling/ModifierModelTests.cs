namespace GqlPlus.Verifier.Modelling;

public class ModifierModelTests
  : ModelBaseTests<ModifierInput>
{
  [Fact]
  public void Model_Nothing()
    => _checks.AstExpected(new(AstNulls.At), ["!_Modifier Optional"]);

  internal override IModelBaseChecks<ModifierInput> BaseChecks => _checks;
  protected override string[] ExpectedBase(ModifierInput input)
    => input.Kind switch {
      ModifierKind.Optional => ["!_Modifier Optional"],
      ModifierKind.List => ["!_Modifier List"],
      ModifierKind.Dict => ["!_Modifier", "key: " + input.Key, "kind: Dict", input.Optional ? "optional: true" : ""],
      _ => [],
    };

  private readonly ModifierModelChecks _checks = new();
}

internal sealed class ModifierModelChecks
  : ModelBaseChecks<ModifierInput, ModifierAst, ModifierModel>
{
  public ModifierModelChecks()
    : base(new ModifierModeller())
  { }

  protected override ModifierAst NewBaseAst(ModifierInput input)
    => input.Kind switch {
      ModifierKind.Optional => ModifierAst.Optional(AstNulls.At),
      ModifierKind.List => ModifierAst.List(AstNulls.At),
      ModifierKind.Dict => new ModifierAst(AstNulls.At, input.Key, input.Optional),
      _ => throw new NotImplementedException(),
    };
}

public record struct ModifierInput(ModifierKind Kind, string Key, bool Optional);
