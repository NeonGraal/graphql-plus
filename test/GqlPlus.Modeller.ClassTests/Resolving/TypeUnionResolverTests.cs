
namespace GqlPlus.Resolving;

public class TypeUnionResolverTests
  : ResolverParentTypeTestBase<TypeUnionModel, NamedModel, UnionMemberModel>
{
  protected override IResolver<TypeUnionModel> Resolver { get; }
    = new TypeUnionResolver();

  protected override Func<NamedModel, UnionMemberModel> AllItem(string name)
    => item => new UnionMemberModel(item.Name, name, item.Description);
  protected override NamedModel NewItem(string name)
    => new(name, "");
  protected override TypeUnionModel NewModel(string name, string description)
    => new(name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Union, parent, description);
}
