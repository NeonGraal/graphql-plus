﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class AstDomainVerifier<TItem>(
  IMerge<TItem> items
) : IVerifyDomain
  where TItem : IGqlpDomainItem
{
  public IMessages CanMergeItems(IGqlpDomain usage, EnumContext context)
  {
    return usage is not IGqlpDomain<TItem> domain
      || !context.GetTyped(domain.Parent?.Name, out IGqlpDomain<TItem>? domainParent)
      ? Messages.New
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

  protected virtual IMessages CanMergeDomain(IGqlpDomain<TItem> domain, IGqlpDomain<TItem> domainParent, EnumContext context)
    => items.CanMerge(domainParent.Items.Concat(domain.Items));
}

public interface IVerifyDomain
{
  void Verify(IGqlpDomain usage, EnumContext context);
  IMessages CanMergeItems(IGqlpDomain usage, EnumContext context);
}
