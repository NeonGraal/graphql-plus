namespace GqlPlus.Resolving;

public class TypeOutputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverAlternateTests()
  {
    Resolver = new TypeOutputResolver();
  }

  protected override OutputAlternateModel MakeAlternate(string alternate)
    => new(new(alternate, ""));
  protected override OutputBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override OutputAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new(alternate, "")) { Collections = [collection] };
  protected override OutputAlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override OutputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
