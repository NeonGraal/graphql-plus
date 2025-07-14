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
    => new(new(alternate, ""));
  protected override InputBaseModel MakeBase(string name, string description = "", params InputArgModel[] args)
    => new(name, description) { Args = args };
  protected override InputAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new(alternate, "")) { Collections = [collection] };
  protected override InputAlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override InputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override InputArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Input, argument, "") { IsTypeParam = isParam };
}
