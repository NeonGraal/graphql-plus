namespace GqlPlus.Resolving;

public class TypeEnumResolverTests
  : ResolverParentTypeTestBase<TypeEnumModel, EnumLabelModel>
{
  protected override IResolver<TypeEnumModel> Resolver { get; }
    = new TypeEnumResolver();

  protected override Func<AliasedModel, EnumLabelModel> AllItem(string name)
    => item => new EnumLabelModel(item.Name, name, item.Description);
  protected override TypeEnumModel NewModel(string name, string description)
    => new(name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Enum, parent, description);
}
