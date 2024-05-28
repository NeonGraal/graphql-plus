namespace GqlPlus.Modelling.Simple;

public class CollectionModelTests(
  IModeller<IGqlpModifier, CollectionModel> modeller
) : TestModelBase<ModifierInput>
{
  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;

  private readonly CollectionModelChecks _checks = new(modeller);

  protected override bool SkipIf(ModifierInput name)
    => name.Kind == ModifierKind.Optional;
}

internal sealed class CollectionModelChecks(
  IModeller<IGqlpModifier, CollectionModel> modeller
) : CheckModelBase<ModifierInput, IGqlpModifier, ModifierAst, CollectionModel>(modeller)
{
  protected override string[] ExpectedBase(ModifierInput name)
    => name.Kind switch {
      ModifierKind.Optional => ["!_Modifier Opt"],
      ModifierKind.List => ["!_Modifier List"],
      ModifierKind.Dict => ["!_ModifierDictionary", "by: " + name.Key, name.Optional ? "optional: true" : ""],
      ModifierKind.Param => ["!_ModifierTypeParameter", name.Optional ? "optional: true" : "", "typeParameter: " + name.Key],
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
