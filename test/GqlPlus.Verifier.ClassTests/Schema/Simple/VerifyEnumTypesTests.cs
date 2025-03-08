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
    ForM<IGqlpEnumItem> mergeMembers = new();
    VerifyEnumTypes verifier = new(Aliased.Intf, mergeMembers.Intf);

    verifier.Verify(UsageAliased, Errors);

    // using AssertionScope scope = new();

    Aliased.Called();
    mergeMembers.NotCalled();
    Errors.ShouldBeEmpty();
  }
}
