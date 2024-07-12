namespace GqlPlus.Modelling;

public class ModifierModelTests(
  ICheckModelBase<ModifierInput, ModifierModel> checks
) : TestModelBase<ModifierInput, ModifierModel>(checks)
{
  [Fact]
  public void Model_Nothing()
    => checks.Model_Expected(
      checks.ToModel(new ModifierAst(AstNulls.At)),
        ["!_Modifier", "modifierKind: !_ModifierKind Opt"]);
}

internal sealed class ModifierModelChecks(
  IModeller<IGqlpModifier, ModifierModel> modeller,
  IRenderer<ModifierModel> rendering
) : CheckModelBase<ModifierInput, IGqlpModifier, ModifierAst, ModifierModel>(modeller, rendering)
{
  protected override string[] ExpectedBase(ModifierInput name)
    => name.Kind switch {
      ModifierKind.Optional => ["!_Modifier", "modifierKind: !_ModifierKind Opt"],
      ModifierKind.List => ["!_Modifier", "modifierKind: !_ModifierKind List"],
      ModifierKind.Dict => ["!_ModifierDictionary", "by: " + name.Key, "modifierKind: !_ModifierKind Dict", name.Optional ? "optional: true" : ""],
      ModifierKind.Param => ["!_ModifierTypeParameter", "by: " + name.Key, "modifierKind: !_ModifierKind Param", name.Optional ? "optional: true" : ""],
      _ => [],
    };

  protected override ModifierAst NewBaseAst(ModifierInput input)
    => input.Kind switch {
      ModifierKind.Optional => ModifierAst.Optional(AstNulls.At),
      ModifierKind.List => ModifierAst.List(AstNulls.At),
      ModifierKind.Dict => ModifierAst.Dict(AstNulls.At, input.Key, input.Optional),
      ModifierKind.Param => ModifierAst.Param(AstNulls.At, input.Key, input.Optional),
      _ => throw new NotImplementedException(),
    };
}

public record struct ModifierInput(ModifierKind Kind, string Key, bool Optional);
