namespace GqlPlus.Resolving.Simple;

internal class ResolverDomainType<TDomain>
  : ResolverParentType<BaseDomainModel<TDomain>, TDomain, DomainItemModel<TDomain>>
  where TDomain : BaseDomainItemModel
{
  protected override DomainItemModel<TDomain> NewItem(BaseDomainModel<TDomain> model, TDomain item)
    => new(item, model.Name);
}
