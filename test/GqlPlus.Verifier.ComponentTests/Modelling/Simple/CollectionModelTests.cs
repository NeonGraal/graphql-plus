namespace GqlPlus.Verifier.Modelling.Types;

public class CollectionModelTests(
  IModeller<ModifierAst, CollectionModel> modeller
) : TestModelBase<ModifierInput>
{
  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;

  private readonly CollectionModelChecks _checks = new(modeller);

  protected override bool SkipIf(ModifierInput name)
    => name.Kind == ModifierKind.Optional;
}

internal sealed class CollectionModelChecks(
  IModeller<ModifierAst, CollectionModel> modeller
) : CheckModelBase<ModifierInput, ModifierAst, CollectionModel>(modeller)
{
  protected override string[] ExpectedBase(ModifierInput name)
    => name.Kind switch {
      ModifierKind.Optional => ["!_Modifier Optional"],
      ModifierKind.List => ["!_Modifier List"],
      ModifierKind.Dict => ["!_ModifierDictionary", "by: " + name.Key, "kind: Dict", name.Optional ? "optional: true" : ""],
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
