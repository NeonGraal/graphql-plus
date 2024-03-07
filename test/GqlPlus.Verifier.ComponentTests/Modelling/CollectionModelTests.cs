namespace GqlPlus.Verifier.Modelling;

public class CollectionModelTests
  : TestModelBase<ModifierInput>
{
  internal override ICheckModelBase<ModifierInput> BaseChecks => _checks;
  protected override string[] ExpectedBase(ModifierInput input)
    => input.Kind switch {
      ModifierKind.Optional => ["!_Modifier Optional"],
      ModifierKind.List => ["!_Modifier List"],
      ModifierKind.Dict => ["!_Modifier", "key: " + input.Key, "kind: Dict", input.Optional ? "optional: true" : ""],
      _ => [],
    };

  private readonly CollectionModelChecks _checks = new();

  protected override bool SkipIf(ModifierInput input)
    => input.Kind == ModifierKind.Optional;
}

internal sealed class CollectionModelChecks
  : CheckModelBase<ModifierInput, ModifierAst, CollectionModel>
{
  public CollectionModelChecks()
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
