namespace GqlPlus.Resolving;

public class TypeOutputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel, ObjTypeArgModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverParentTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeOutputResolver(dual);
  }

  protected override OutputBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override OutputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
