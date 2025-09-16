namespace GqlPlus.Resolving;

public class TypeOutputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, ObjAlternateModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverParentTests()
  {
    Resolver = new TypeOutputResolver();
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
