using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Schema.Simple;

[TracePerTest]
public class VerifyEnumTypesTests
  : UsageVerifierBase<IGqlpEnum>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    ForM<IGqlpEnumLabel> mergeMembers = new();
    VerifyEnumTypes verifier = new(Aliased.Intf, mergeMembers.Intf);

    verifier.Verify(UsageAliased, Errors);

    verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      mergeMembers.NotCalled,
      () => Errors.ShouldBeEmpty());
  }
}
