
namespace GqlPlus.Resolving;

public class TypeUnionResolverTests
  : ResolverParentTypeTestBase<TypeUnionModel, UnionMemberModel>
{
  protected override IResolver<TypeUnionModel> Resolver { get; }
    = new TypeUnionResolver();

  protected override Func<AliasedModel, UnionMemberModel> AllItem(string name)
    => item => new UnionMemberModel(item.Name, name, item.Description);
  protected override TypeUnionModel NewModel(string name, string description)
    => new(name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Union, parent, description);
}
