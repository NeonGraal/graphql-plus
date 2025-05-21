
namespace GqlPlus.Resolving;

public class TypeInputResolverTests
  : ResolverTypeObjectTypeTestBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeInputResolver(dual);
  }

  protected override InputAlternateModel MakeAlternate(string alternate) => new(alternate, "");
  protected override InputFieldModel MakeField(FieldInput field) => new(field.Name, new(field.Type, ""), "");
  protected override InputBaseModel NewParent(string parent, string description) => new(parent, description);
  protected override TypeInputModel NewModel(string name, string description) => new(name, description);
}
