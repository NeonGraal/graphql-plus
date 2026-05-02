namespace GqlPlus.Resolving.Objects;

public class TypeInputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverParentTests()
  {
    IResolver<TypeDualModel> dualResolver = RFor<TypeDualModel>();
    IResolverRepository resolvers = A.Of<IResolverRepository>();
    ResolveForReturns(resolvers, dualResolver);
    Resolver = new TypeInputResolver(resolvers);
  }

  protected override ObjBaseModel MakeBase(string name, string description = "", params ITypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ITypeArgModel NewArg(string argument, bool isParam = false)
    => new TypeArgModel(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
