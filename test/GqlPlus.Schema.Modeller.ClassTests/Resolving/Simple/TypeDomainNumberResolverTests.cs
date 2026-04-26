namespace GqlPlus.Resolving.Simple;

public class TypeDomainNumberResolverTests
  : ResolverParentTypeTestBase<BaseDomainModel<DomainRangeModel>, DomainRangeInput, DomainRangeModel, DomainItemModel<DomainRangeModel>>
{
  protected override IResolver<BaseDomainModel<DomainRangeModel>> Resolver { get; }
    = new ResolverDomainType<DomainRangeModel>();

  protected override Func<DomainRangeModel, DomainItemModel<DomainRangeModel>> AllItem(string name)
    => item => new DomainItemModel<DomainRangeModel>(item, name);
  protected override DomainRangeModel NewItem(DomainRangeInput input) => new(input.Lower, input.Upper, false, "");
  protected override BaseDomainModel<DomainRangeModel> NewModel(string name, string description)
    => new(DomainKindModel.Number, name, description);
  protected override TypeRefModel<SimpleKindModel> NewParent(string parent, string description)
    => new(SimpleKindModel.Domain, parent, description);
}
