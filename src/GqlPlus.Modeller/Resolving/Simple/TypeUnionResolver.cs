namespace GqlPlus.Resolving.Simple;

internal class TypeUnionResolver
  : ResolverParentType<TypeUnionModel, NamedModel, UnionMemberModel>
{
  protected override UnionMemberModel NewItem(TypeUnionModel model, NamedModel item)
    => new(item.Name, model.Name, item.Description);
}
