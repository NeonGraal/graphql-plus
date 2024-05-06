using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class AstDomainVerifier<TMember>(
  IMerge<TMember> members
) : IVerifyDomain
  where TMember : AstAbbreviated, IGqlpDomainItem
{
  public ITokenMessages CanMergeItems(IGqlpDomain usage, EnumContext context)
  {
    return usage is not IGqlpDomain<TMember> domain
      || !context.GetType(domain.Parent, out IGqlpDescribed? type)
      || type is not IGqlpDomain<TMember> domainParent
      ? new TokenMessages()
      : CanMergeDomain(domain, domainParent, context);
  }

  public void Verify(IGqlpDomain usage, EnumContext context)
  {
    if (usage is IGqlpDomain<TMember> domain) {
      VerifyDomain(domain, context);
    }
  }

  protected virtual void VerifyDomain(IGqlpDomain<TMember> domain, EnumContext context)
  { }

  protected virtual ITokenMessages CanMergeDomain(IGqlpDomain<TMember> domain, IGqlpDomain<TMember> domainParent, EnumContext context)
    => members.CanMerge(domainParent.Items.Concat(domain.Items));
}

public interface IVerifyDomain
{
  void Verify(IGqlpDomain usage, EnumContext context);
  ITokenMessages CanMergeItems(IGqlpDomain usage, EnumContext context);
}
