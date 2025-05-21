
namespace GqlPlus.Resolving;

public class TypeDualResolverTests
  : ResolverTypeObjectTypeTestBase<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  protected override DualAlternateModel MakeAlternate(string alternate)
    => new(alternate, "");
  protected override DualFieldModel MakeField(FieldInput field)
    => new(field.Name, new(field.Type, ""), "");
  protected override TypeDualModel NewModel(string name, string description)
    => new(name, description);
  protected override DualBaseModel NewParent(string parent, string description)
    => new(parent, description);
}
