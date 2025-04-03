using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Token;

namespace GqlPlus.Verifying.Schema.Simple;

internal class AstDomainVerifier<TItem>(
  IMerge<TItem> items
) : IVerifyDomain
  where TItem : IGqlpDomainItem
{
  public ITokenMessages CanMergeItems(IGqlpDomain usage, EnumContext context)
  {
    return usage is not IGqlpDomain<TItem> domain
      || !context.GetType(domain.Parent, out IGqlpDescribed? type)
      || type is not IGqlpDomain<TItem> domainParent
      ? TokenMessages.New
      : CanMergeDomain(domain, domainParent, context);
  }

  public void Verify(IGqlpDomain usage, EnumContext context)
  {
    if (usage is IGqlpDomain<TItem> domain) {
      VerifyDomain(domain, context);
    }
  }

  protected virtual void VerifyDomain(IGqlpDomain<TItem> domain, EnumContext context)
  { }

  protected virtual ITokenMessages CanMergeDomain(IGqlpDomain<TItem> domain, IGqlpDomain<TItem> domainParent, EnumContext context)
    => items.CanMerge(domainParent.Items.Concat(domain.Items));
}

public interface IVerifyDomain
{
  void Verify(IGqlpDomain usage, EnumContext context);
  ITokenMessages CanMergeItems(IGqlpDomain usage, EnumContext context);
}
