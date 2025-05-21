
namespace GqlPlus.Resolving;

public class TypeOutputResolverTests
  : ResolverTypeObjectTypeTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeOutputResolver(dual);
  }

  protected override OutputAlternateModel MakeAlternate(string alternate) => new(alternate, "");
  protected override OutputFieldModel MakeField(FieldInput field) => new(field.Name, new(field.Type, ""), "");
  protected override OutputBaseModel NewParent(string parent, string description) => new(parent, description);
  protected override TypeOutputModel NewModel(string name, string description) => new(name, description);
}
