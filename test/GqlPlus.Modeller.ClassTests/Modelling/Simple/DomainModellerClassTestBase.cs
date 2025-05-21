
namespace GqlPlus.Modelling.Simple;

public abstract class DomainModellerClassTestBase<TItemAst, TItemModel>
  : ModellerClassTestBase<IGqlpDomain<TItemAst>, BaseDomainModel<TItemModel>>
  where TItemAst : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
{
  protected abstract IDomainModeller<TItemAst, TItemModel> DomainModeller { get; }
  protected sealed override IModeller<IGqlpDomain<TItemAst>, BaseDomainModel<TItemModel>> Modeller => DomainModeller;
}
