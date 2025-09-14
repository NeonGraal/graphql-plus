namespace GqlPlus.Resolving;

public class TypeInputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverParentTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeInputResolver(dual);
  }

  protected override InputBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override InputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
