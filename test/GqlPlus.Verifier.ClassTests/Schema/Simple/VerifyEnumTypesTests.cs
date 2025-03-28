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
    ForM<IGqlpEnumLabel> mergeLabels = new();
    VerifyEnumTypes verifier = new(Aliased.Intf, mergeLabels.Intf);

    verifier.Verify(UsageAliased, Errors);

    verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      mergeLabels.NotCalled,
      () => Errors.ShouldBeEmpty());
  }
}
