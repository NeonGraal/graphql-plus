﻿namespace GqlPlus.Modelling.Simple;

public class CollectionModelTests(
  IModeller<IGqlpModifier, CollectionModel> modeller,
  IRenderer<CollectionModel> rendering
) : TestModelBase<ModifierInput>
{
  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;

  private readonly CollectionModelChecks _checks = new(modeller, rendering);

  protected override bool SkipIf(ModifierInput name)
    => name.Kind == ModifierKind.Optional;
}

internal sealed class CollectionModelChecks(
  IModeller<IGqlpModifier, CollectionModel> modeller,
  IRenderer<CollectionModel> rendering
) : CheckModelBase<ModifierInput, IGqlpModifier, ModifierAst, CollectionModel>(modeller, rendering)
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
