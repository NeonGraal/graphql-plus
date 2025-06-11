namespace GqlPlus.Verifying.Schema.Simple;

public abstract class AstDomainVerifierTestsBase<TItem>
  : VerifierTypeTestsBase
  where TItem : class, IGqlpDomainItem
{
  internal ForM<TItem> ItemsMerger { get; } = new();

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpDomain<TItem> domain = A.Domain<TItem>("", DomainKind.Boolean);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void CanMerge_WithParentIems_WithoutErrors()
  {
    TItem parentItem = A.Error<TItem>();
    IGqlpDomain<TItem> parent = A.Domain("parent", DomainKind.Boolean, parentItem);
    AddTypes(parent);

    IGqlpDomain<TItem> domain = A.Domain<TItem>("domain", [], "parent", "", DomainKind.Boolean);

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
