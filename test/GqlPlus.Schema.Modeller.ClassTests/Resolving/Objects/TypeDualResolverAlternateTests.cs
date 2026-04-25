namespace GqlPlus.Resolving.Objects;

public class TypeDualResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeDualModel, DualFieldModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  protected override AlternateModel MakeAlternate(string alternate)
    => new(new ObjBaseModel(alternate, ""));
  protected override ObjBaseModel MakeBase(string name, string description = "", params TypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override AlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "")) { Collections = [collection] };
  protected override AlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Dual, argument, "") { IsTypeParam = isParam };
  protected override TypeDualModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
}
