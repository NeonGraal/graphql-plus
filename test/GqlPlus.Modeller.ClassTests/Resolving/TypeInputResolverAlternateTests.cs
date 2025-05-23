namespace GqlPlus.Resolving;

public class TypeInputResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel, InputArgModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverAlternateTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeInputResolver(dual);
  }

  protected override InputAlternateModel MakeAlternate(string alternate)
    => new(alternate, "");
  protected override InputBaseModel MakeBase(string name, string description = "", params InputArgModel[] args)
    => new(name, description) { Args = args };
  protected override InputAlternateModel MakeParamAlternate(string alternate)
    => new(alternate, "") { IsTypeParam = true };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override InputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override InputArgModel NewArg(string argument, bool isParam = false)
    => new(argument, "") { IsTypeParam = isParam };
}
