using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Schema.Simple;

[TracePerTest]
public class VerifyUnionTypesTests
  : UsageVerifierBase<IGqlpUnion>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    ForM<IGqlpUnionMember> mergeMembers = new();
    VerifyUnionTypes verifier = new(Aliased.Intf, mergeMembers.Intf);

    verifier.Verify(UsageAliased, Errors);

    verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      mergeMembers.NotCalled,
      () => Errors.ShouldBeEmpty());
  }
}
