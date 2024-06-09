using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Simple;

public class ModifierModelTests(
  IModeller<IGqlpModifier, ModifierModel> modeller,
  IRenderer<ModifierModel> rendering
) : TestModelBase<ModifierInput>
{
  [Fact]
  public void Model_Nothing()
    => _checks.AstExpected(new(AstNulls.At), ["!_Modifier", "modifierKind: !_ModifierKind Opt"]);

  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;

  private readonly ModifierModelChecks _checks = new(modeller, rendering);
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
