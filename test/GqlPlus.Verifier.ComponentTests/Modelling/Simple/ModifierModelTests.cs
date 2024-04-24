namespace GqlPlus.Verifier.Modelling.Simple;

public class ModifierModelTests(
  IModeller<ModifierAst, ModifierModel> modeller
) : TestModelBase<ModifierInput>
{
  [Fact]
  public void Model_Nothing()
    => _checks.AstExpected(new(AstNulls.At), ["!_Modifier Optional"]);

  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;

  private readonly ModifierModelChecks _checks = new(modeller);
}

internal sealed class ModifierModelChecks(
  IModeller<ModifierAst, ModifierModel> modeller
) : CheckModelBase<ModifierInput, ModifierAst, ModifierModel>(modeller)
{
  protected override string[] ExpectedBase(ModifierInput name)
    => name.Kind switch {
      ModifierKind.Optional => ["!_Modifier Optional"],
      ModifierKind.List => ["!_Modifier List"],
      ModifierKind.Dict => ["!_ModifierDictionary", "by: " + name.Key, "modifierKind: Dict", name.Optional ? "optional: true" : ""],
      _ => [],
    };

  protected override ModifierAst NewBaseAst(ModifierInput input)
    => input.Kind switch {
      ModifierKind.Optional => ModifierAst.Optional(AstNulls.At),
      ModifierKind.List => ModifierAst.List(AstNulls.At),
      ModifierKind.Dict => new ModifierAst(AstNulls.At, input.Key, input.Optional),
      _ => throw new NotImplementedException(),
    };
}

public record struct ModifierInput(ModifierKind Kind, string Key, bool Optional);
