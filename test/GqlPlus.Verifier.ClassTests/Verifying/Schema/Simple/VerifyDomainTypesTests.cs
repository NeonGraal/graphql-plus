using System;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainTypesTests
  : UsageVerifierBase<IGqlpDomain>
{
  private readonly IEnumerable<IVerifyDomain> _domains = For<IEnumerable<IVerifyDomain>>();
  private readonly VerifyDomainTypes _verifier;

  private readonly IGqlpDomain _domain;

  public VerifyDomainTypesTests()
  {
    _verifier = new(Aliased.Intf, _domains);

    _domain = For<IGqlpDomain>();
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Domain_ReturnsNoErrors()
  {
    Usages.Add(_domain);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
