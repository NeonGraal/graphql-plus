using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema.Simple;

internal class AstDomainVerifier<TMember>(
  IMerge<TMember> members
) : IVerifyDomain
  where TMember : AstAbbreviated, IAstDomainItem
{
  public ITokenMessages CanMergeItems(AstDomain usage, EnumContext context)
  {
    return usage is not AstDomain<TMember> domain
|| !context.GetType(domain.Parent, out Ast.Schema.AstDescribed? type)
      || type is not AstDomain<TMember> domainParent
      ? new TokenMessages()
      : CanMergeDomain(domain, domainParent, context);
  }

  public void Verify(AstDomain usage, EnumContext context)
  {
    if (usage is AstDomain<TMember> domain) {
      VerifyDomain(domain, context);
    }
  }

  protected virtual void VerifyDomain(AstDomain<TMember> domain, EnumContext context)
  { }

  protected virtual ITokenMessages CanMergeDomain(AstDomain<TMember> domain, AstDomain<TMember> domainParent, EnumContext context)
    => members.CanMerge(domainParent.Members.Concat(domain.Members));
}

public interface IVerifyDomain
{
  void Verify(AstDomain usage, EnumContext context);
  ITokenMessages CanMergeItems(AstDomain usage, EnumContext context);
}
