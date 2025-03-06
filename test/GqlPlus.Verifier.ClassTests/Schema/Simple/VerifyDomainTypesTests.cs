using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Schema.Simple;

[TracePerTest]
public class VerifyDomainTypesTests
  : UsageVerifierBase<IGqlpDomain>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IEnumerable<IVerifyDomain> domains = For<IEnumerable<IVerifyDomain>>();
    VerifyDomainTypes verifier = new(Aliased.Intf, domains);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.Called();
    Errors.Should().BeNullOrEmpty();
  }
}
