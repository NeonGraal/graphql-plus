namespace GqlPlus.Resolving;

public class TypeDualResolverAlternateTests
  : ResolverTypeObjectAlternateTestBase<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel, DualArgModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  protected override DualAlternateModel MakeAlternate(string alternate)
    => new(new(alternate, ""));
  protected override DualBaseModel MakeBase(string name, string description = "", params DualArgModel[] args)
    => new(name, description) { Args = args };
  protected override DualAlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection)
    => new(new(alternate, "")) { Collections = [collection] };
  protected override DualAlternateModel MakeParamAlternate(string alternate, CollectionModel collection)
    => new(new(alternate, "") { IsTypeParam = true }) { Collections = [collection] };
  protected override DualArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Dual, argument, "") { IsTypeParam = isParam };
  protected override TypeDualModel NewModel(string name, string description)
    => new(name, description);
  protected override DualBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
}
