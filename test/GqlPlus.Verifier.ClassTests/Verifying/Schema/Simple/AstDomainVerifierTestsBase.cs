using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema.Simple;

public abstract class AstDomainVerifierTestsBase<TItem>(
  DomainKind kind
) : VerifierTypeTestsBase
  where TItem : class, IGqlpDomainItem
{
  internal ForM<TItem> ItemsMerger { get; } = new();

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    TItem item = NewItem();
    IGqlpDomain<TItem> domain = A.Domain("", kind, item);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void CanMerge_WithParentIems_WithoutErrors()
  {
    TItem parentItem = A.Error<TItem>();
    IGqlpDomain<TItem> parent = A.Domain("parent", kind, parentItem);
    AddTypes(parent);

    IGqlpDomain<TItem> domain = A.Domain<TItem>("domain", kind)
      .WithParent("parent").AsDomain;

    EnumContext context = new(Types, Errors, EnumValues);

    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    IMessages result = verifier.CanMergeItems(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.Called,
      () => Errors.ShouldBeEmpty(),
      () => result.ShouldBeEmpty());
  }

  internal virtual AstDomainVerifier<TItem> NewDomainVerifier()
    => new(ItemsMerger.Intf);

  internal virtual TItem NewItem()
    => A.Error<TItem>();
}
