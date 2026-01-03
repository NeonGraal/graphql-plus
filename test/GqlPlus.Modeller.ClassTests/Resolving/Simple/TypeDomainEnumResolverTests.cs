
namespace GqlPlus.Resolving.Simple;

public class TypeDomainEnumResolverTests
  : ResolverParentTypeTestBase<BaseDomainModel<DomainLabelModel>, EnumLabelInput, DomainLabelModel, DomainItemModel<DomainLabelModel>>
{
  [Theory, RepeatData]
  public void CreatesModel_WithAllEnum(string name, string enumType, string[] labels)
  {
    this.SkipEqual(name, enumType);

    TypeEnumModel enumModel = new(enumType, "") {
      Items = [.. labels.Select(label => new AliasedModel(label, ""))],
      AllItems = [.. labels.Select(e => new EnumLabelModel(e, enumType, ""))]
    };
    Context.AddModels([enumModel]);

    DomainLabelModel itemModel = NewItem(new(enumType, "*"));
    BaseDomainModel<DomainLabelModel> model = NewModel(name, "") with {
      Items = [itemModel],
    };

    DomainItemModel<DomainLabelModel>[] expected = [.. labels
      .Select(label => AllItem(name)(NewItem(new(enumType, label))))];

    BaseDomainModel<DomainLabelModel> result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllItems.ShouldBeEquivalentTo(expected));
  }

  [Theory, RepeatData]
  public void CreatesModel_WithParentEnum(string name, string enumType, string parentEnum, string[] labels)
  {
    this.SkipEqual3(name, enumType, parentEnum);

    TypeEnumModel parentModel = new(parentEnum, "") {
      Items = [.. labels.Select(label => new AliasedModel(label, ""))],
      AllItems = [.. labels.Select(e => new EnumLabelModel(e, parentEnum, ""))]
    };
    TypeEnumModel enumModel = new(enumType, "") {
      Parent = new TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, parentEnum, ""),
    };
    Context.AddModels([enumModel, parentModel]);

    DomainLabelModel itemModel = NewItem(new(enumType, "*"));
    BaseDomainModel<DomainLabelModel> model = NewModel(name, "") with {
      Items = [itemModel],
    };

    DomainItemModel<DomainLabelModel>[] expected = [.. labels
      .Select(label => AllItem(name)(NewItem(new(parentEnum, label))))];

    BaseDomainModel<DomainLabelModel> result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllItems.ShouldBeEquivalentTo(expected));
  }

  protected override IResolver<BaseDomainModel<DomainLabelModel>> Resolver { get; }
    = new TypeDomainEnumResolver();

  protected override Func<DomainLabelModel, DomainItemModel<DomainLabelModel>> AllItem(string name)
    => item => new DomainItemModel<DomainLabelModel>(item, name);
  protected override DomainLabelModel NewItem(EnumLabelInput input) => new(input.EnumType, input.Label, false, "");
  protected override BaseDomainModel<DomainLabelModel> NewModel(string name, string description)
    => new(DomainKindModel.Enum, name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Domain, parent, description);
  protected override bool DuplicateItems(EnumLabelInput[] items)
    => items.ThrowIfNull().Length != items.DistinctBy(i => i.Label).Count();
}
