namespace GqlPlus.Resolving;

public class TypeInputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel, InputArgModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverParentTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeInputResolver(dual);
  }

  protected override InputBaseModel MakeBase(string name, string description = "", params InputArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override InputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override InputArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
