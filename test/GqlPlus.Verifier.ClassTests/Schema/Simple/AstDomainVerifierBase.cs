using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public abstract class AstDomainVerifierBase<TMember>
  : VerifierBase
  where TMember : class, IGqlpDomainItem
{
  internal ForM<TMember> Members { get; } = new();
  protected IMap<string> EnumValues { get; } = new Map<string>();
  protected IMap<IGqlpDescribed> Types { get; } = new Map<IGqlpDescribed>();

  [Fact]
  public void Verify_WithoutErrors()
  {
    AstDomainVerifier<TMember> verifier = NewDomainVerifier();

    EnumContext context = new(Types, Errors, EnumValues);

    IGqlpDomain<TMember> domain = EFor<IGqlpDomain<TMember>>();

    verifier.Verify(domain, context);

    verifier.ShouldSatisfyAllConditions(
      Members.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  internal virtual AstDomainVerifier<TMember> NewDomainVerifier()
    => new(Members.Intf);
}
