using GqlPlus.Ast.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class AstDomainVerifier<TItem>(
  IVerifierRepository verifiers
) : IVerifyDomain
  where TItem : IAstDomainItem
{
  private readonly IMerge<TItem> _items = verifiers.MergerFor<TItem>();

  public IMessages CanMergeItems(IAstDomain usage, EnumContext context)
  {
    return usage is not IAstDomain<TItem> domain
      || !context.GetTyped(domain.Parent?.Name, out IAstDomain<TItem>? domainParent)
      ? Messages.New
      : CanMergeDomain(domain, domainParent, context);
  }

  public void Verify(IAstDomain usage, EnumContext context)
  {
    if (usage is IAstDomain<TItem> domain) {
      VerifyDomain(domain, context);
    }
  }

  protected virtual void VerifyDomain(IAstDomain<TItem> domain, EnumContext context)
  { }

  protected virtual IMessages CanMergeDomain(IAstDomain<TItem> domain, IAstDomain<TItem> domainParent, EnumContext context)
    => _items.CanMerge(domainParent.Items.Concat(domain.Items));
}

public interface IVerifyDomain
{
  void Verify(IAstDomain usage, EnumContext context);
  IMessages CanMergeItems(IAstDomain usage, EnumContext context);
}
