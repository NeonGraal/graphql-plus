﻿namespace GqlPlus.Modelling.Simple;

public class ModifierModelTests(
  IModeller<IGqlpModifier, ModifierModel> modeller
) : TestModelBase<ModifierInput>
{
  [Fact]
  public void Model_Nothing()
    => _checks.AstExpected(new(AstNulls.At), ["!_Modifier Opt"]);

  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;

  private readonly ModifierModelChecks _checks = new(modeller);
}

internal sealed class ModifierModelChecks(
  IModeller<IGqlpModifier, ModifierModel> modeller
) : CheckModelBase<ModifierInput, IGqlpModifier, ModifierAst, ModifierModel>(modeller)
{
  protected override string[] ExpectedBase(ModifierInput name)
    => name.Kind switch {
      ModifierKind.Optional => ["!_Modifier Opt"],
      ModifierKind.List => ["!_Modifier List"],
      ModifierKind.Dict => ["!_ModifierDictionary", "key: " + name.Key, name.Optional ? "optional: true" : ""],
      ModifierKind.Param => ["!_ModifierTypeParameter", "key: " + name.Key, name.Optional ? "optional: true" : ""],
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
