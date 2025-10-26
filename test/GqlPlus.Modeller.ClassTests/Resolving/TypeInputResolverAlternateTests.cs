namespace GqlPlus.Resolving;

public class TypeInputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverAlternateTests() => Resolver = new TypeInputResolver();

  protected override AlternateModel MakeAlternate(string alternate)
    => new(new ObjBaseModel(alternate, ""));
  protected override ObjBaseModel MakeBase(string name, string description = "", params TypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override AlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "")) { Collections = [collection] };
  protected override AlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override TypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Input, argument, "") { IsTypeParam = isParam };
}
