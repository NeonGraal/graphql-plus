namespace GqlPlus.Resolving;

public class TypeDualResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeDualModel, DualBaseModel, DualFieldModel, ObjAlternateModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  protected override ObjAlternateModel MakeAlternate(string alternate)
    => new(new DualBaseModel(alternate, ""));
  protected override DualBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override ObjAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new DualBaseModel(alternate, "")) { Collections = [collection] };
  protected override ObjAlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new DualBaseModel(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Dual, argument, "") { IsTypeParam = isParam };
  protected override TypeDualModel NewModel(string name, string description)
    => new(name, description);
  protected override DualBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
}
