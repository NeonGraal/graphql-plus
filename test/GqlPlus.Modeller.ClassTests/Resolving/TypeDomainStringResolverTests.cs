
namespace GqlPlus.Resolving;

public class TypeDomainStringResolverTests
  : ResolverParentTypeTestBase<BaseDomainModel<DomainRegexModel>, DomainRegexModel, DomainItemModel<DomainRegexModel>>
{
  protected override IResolver<BaseDomainModel<DomainRegexModel>> Resolver { get; }
    = new ResolverDomainType<DomainRegexModel>();

  protected override Func<DomainRegexModel, DomainItemModel<DomainRegexModel>> AllItem(string name)
    => item => new DomainItemModel<DomainRegexModel>(item, name);
  protected override DomainRegexModel NewItem(string name) => new(name, false);
  protected override BaseDomainModel<DomainRegexModel> NewModel(string name, string description)
    => new(DomainKindModel.String, name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Domain, parent, description);
}
