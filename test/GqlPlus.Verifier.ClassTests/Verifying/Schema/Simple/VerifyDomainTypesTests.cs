using GqlPlus.Abstractions.Schema;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainTypesTests
  : UsageVerifierBase<IGqlpDomain>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IEnumerable<IVerifyDomain> domains = For<IEnumerable<IVerifyDomain>>();
    VerifyDomainTypes verifier = new(Aliased, domains);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpDomain[]>(), Errors);
    Errors.Should().BeNullOrEmpty();
  }
}
