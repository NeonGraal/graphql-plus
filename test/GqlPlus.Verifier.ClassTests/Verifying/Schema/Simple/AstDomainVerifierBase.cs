using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

public abstract class AstDomainVerifierBase<TItem>
  : VerifierBase
  where TItem : class, IGqlpDomainItem
{
  internal ForM<TItem> Items { get; } = new();
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IGqlpDescribed> Types { get; } = new Map<IGqlpDescribed>();

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TItem> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpDomain<TItem> domain = EFor<IGqlpDomain<TItem>>();

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      Items.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  internal virtual AstDomainVerifier<TItem> NewDomainVerifier()
    => new(Items.Intf);
}
