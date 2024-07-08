namespace GqlPlus.Resolving;

internal class TypeEnumResolver
  : ResolverParentType<TypeEnumModel, AliasedModel, EnumMemberModel>
{
  protected override EnumMemberModel NewItem(TypeEnumModel model, AliasedModel item)
    => new(item.Name, model.Name) {
      Aliases = item.Aliases,
    };
}
