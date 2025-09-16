namespace GqlPlus.Resolving;

public class TypeOutputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, ObjAlternateModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverAlternateTests()
  {
    Resolver = new TypeOutputResolver();
  }

  protected override ObjAlternateModel MakeAlternate(string alternate)
    => new(new OutputBaseModel(alternate, ""));
  protected override OutputBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override ObjAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new OutputBaseModel(alternate, "")) { Collections = [collection] };
  protected override ObjAlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new OutputBaseModel(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override OutputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
