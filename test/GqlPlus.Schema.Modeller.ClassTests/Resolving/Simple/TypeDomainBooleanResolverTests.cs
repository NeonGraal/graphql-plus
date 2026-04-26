namespace GqlPlus.Resolving.Simple;

public class TypeDomainBooleanResolverTests
  : ResolverParentTypeTestBase<BaseDomainModel<DomainTrueFalseModel>, bool, DomainTrueFalseModel, DomainItemModel<DomainTrueFalseModel>>
{
  protected override IResolver<BaseDomainModel<DomainTrueFalseModel>> Resolver { get; }
    = new ResolverDomainType<DomainTrueFalseModel>();

  protected override Func<DomainTrueFalseModel, DomainItemModel<DomainTrueFalseModel>> AllItem(string name)
    => item => new DomainItemModel<DomainTrueFalseModel>(item, name);
  protected override DomainTrueFalseModel NewItem(bool input) => new(input, false, "");
  protected override BaseDomainModel<DomainTrueFalseModel> NewModel(string name, string description)
    => new(DomainKindModel.Boolean, name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Domain, parent, description);
}
