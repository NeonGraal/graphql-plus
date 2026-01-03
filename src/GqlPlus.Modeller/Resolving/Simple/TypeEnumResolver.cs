namespace GqlPlus.Resolving.Simple;

internal class TypeEnumResolver
  : ResolverParentType<TypeEnumModel, AliasedModel, EnumLabelModel>
{
  protected override EnumLabelModel NewItem(TypeEnumModel model, AliasedModel item)
    => new(item.Name, model.Name, item.Description) {
      Aliases = item.Aliases,
    };
}
