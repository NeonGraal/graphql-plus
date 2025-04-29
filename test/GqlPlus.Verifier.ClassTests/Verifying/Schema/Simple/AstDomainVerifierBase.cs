using DiffEngine;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

public abstract class AstDomainVerifierBase<TItem>
  : VerifierTypeBase
  where TItem : class, IGqlpDomainItem
{
  internal ForM<TItem> ItemsMerger { get; } = new();

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpDomain<TItem> domain = EFor<IGqlpDomain<TItem>>();

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void CanMerge_WithParentIems_WithoutErrors()
  {
    IGqlpDomain<TItem> parent = NFor<IGqlpDomain<TItem>>("parent");
    TItem parentItem = EFor<TItem>();
    parent.Items.Returns([parentItem]);
    Types["parent"] = parent;

    IGqlpDomain<TItem> domain = NFor<IGqlpDomain<TItem>>("domain");
    domain.Parent.Returns("parent");

    EnumContext context = new(Types, Errors, EnumValues);

    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    ITokenMessages result = verifier.CanMergeItems(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.Called,
      () => Errors.ShouldBeEmpty(),
      () => result.ShouldBeEmpty());
  }

  internal virtual AstDomainVerifier<TItem> NewDomainVerifier()
    => new(ItemsMerger.Intf);
}
