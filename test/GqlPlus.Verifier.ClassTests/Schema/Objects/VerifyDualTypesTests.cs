using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Objects;

namespace GqlPlus.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : UsageVerifierBase<IGqlpDualObject>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    ForM<IGqlpDualField> fields = new();
    ForM<IGqlpDualAlternate> mergeAlternates = new();
    VerifyDualTypes verifier = new(Aliased.Intf, fields.Intf, mergeAlternates.Intf, Logger);

    verifier.Verify(UsageAliased, Errors);

    // using AssertionScope scope = new();

    Aliased.Called();
    fields.NotCalled();
    mergeAlternates.NotCalled();
    Errors.ShouldBeEmpty();
  }
}
