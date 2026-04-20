using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema.Simple;

public abstract class AstDomainVerifierTestsBase<TItem>
  : VerifierTypeTestsBase
  where TItem : class, IAstDomainItem
{
  private readonly DomainKind _kind;
  internal ForM<TItem> ItemsMerger { get; } = new();

  protected AstDomainVerifierTestsBase(DomainKind kind)
  {
    _kind = kind;
    VerifierRepo.MergerFor<TItem>().Returns(ItemsMerger.Intf);
  }

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    TItem item = NewItem();
    IAstDomain<TItem> domain = A.Domain("", _kind, item);

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      ItemsMerger.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void CanMerge_WithParentIems_WithoutErrors()
  {
    TItem parentItem = A.Error<TItem>();
    IAstDomain<TItem> parent = A.Domain("parent", _kind, parentItem);
    AddTypes(parent);

    IAstDomain<TItem> domain = A.Domain<TItem>("domain", _kind)
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
    => new(VerifierRepo);

  internal virtual TItem NewItem()
    => A.Error<TItem>();
}
