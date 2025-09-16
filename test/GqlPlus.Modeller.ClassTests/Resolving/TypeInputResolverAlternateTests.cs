namespace GqlPlus.Resolving;

public class TypeInputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverAlternateTests()
  {
    Resolver = new TypeInputResolver();
  }

  protected override ObjAlternateModel MakeAlternate(string alternate)
    => new(new ObjBaseModel(alternate, ""));
  protected override ObjBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override ObjAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "")) { Collections = [collection] };
  protected override ObjAlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Input, argument, "") { IsTypeParam = isParam };
}
