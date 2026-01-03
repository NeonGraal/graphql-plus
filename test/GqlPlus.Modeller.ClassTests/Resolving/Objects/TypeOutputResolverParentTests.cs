namespace GqlPlus.Resolving.Objects;

public class TypeOutputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeOutputModel, OutputFieldModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverParentTests() => Resolver = new TypeOutputResolver();

  protected override ObjBaseModel MakeBase(string name, string description = "", params TypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override TypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
