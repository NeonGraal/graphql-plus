namespace GqlPlus.Resolving;

internal class TypeUnionResolver
  : ResolverParentType<TypeUnionModel, AliasedModel, UnionMemberModel>
{
  protected override UnionMemberModel NewItem(TypeUnionModel model, AliasedModel item)
    => new(item.Name, model.Name);
}
