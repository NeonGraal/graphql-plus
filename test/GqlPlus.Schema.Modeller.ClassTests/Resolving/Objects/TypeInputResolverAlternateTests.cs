namespace GqlPlus.Resolving.Objects;

public class TypeInputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverAlternateTests()
  {
    IResolver<TypeDualModel> dualResolver = RFor<TypeDualModel>();
    IResolverRepository resolvers = A.Of<IResolverRepository>();
    resolvers.ResolverFor<TypeDualModel>().Returns(dualResolver);
    Resolver = new TypeInputResolver(resolvers);
  }

  protected override AlternateModel MakeAlternate(string alternate)
    => new(new ObjBaseModel(alternate, ""));
  protected override ObjBaseModel MakeBase(string name, string description = "", params ITypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override AlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "")) { Collections = [collection] };
  protected override AlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new ObjBaseModel(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ITypeArgModel NewArg(string argument, bool isParam = false)
    => new TypeArgModel(TypeKindModel.Input, argument, "") { IsTypeParam = isParam };
}
