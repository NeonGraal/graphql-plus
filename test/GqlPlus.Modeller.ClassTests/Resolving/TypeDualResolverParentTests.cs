namespace GqlPlus.Resolving;

public class TypeDualResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel, DualArgModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  protected override DualBaseModel MakeBase(string name, string description = "", params DualArgModel[] args)
    => new(name, description) { Args = args };
  protected override DualArgModel NewArg(string argument, bool isParam = false)
    => new(argument, "") { IsTypeParam = isParam };
  protected override TypeDualModel NewModel(string name, string description)
    => new(name, description);
  protected override DualBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
}
