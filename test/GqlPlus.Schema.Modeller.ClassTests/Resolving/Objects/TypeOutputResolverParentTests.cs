namespace GqlPlus.Resolving.Objects;

public class TypeOutputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeOutputModel, OutputFieldModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverParentTests()
  {
    IResolver<TypeDualModel> dualResolver = RFor<TypeDualModel>();
    IResolverRepository resolvers = A.Of<IResolverRepository>();
    ResolveForReturns(resolvers, dualResolver);
    Resolver = new TypeOutputResolver(resolvers);
  }

  protected override ObjBaseModel MakeBase(string name, string description = "", params ITypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ITypeArgModel NewArg(string argument, bool isParam = false)
    => new TypeArgModel(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
