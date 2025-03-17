using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Objects;

namespace GqlPlus.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : UsageVerifierBase<IGqlpOutputObject>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    ForM<IGqlpOutputField> fields = new();
    ForM<IGqlpOutputAlternate> mergeAlternates = new();
    VerifyOutputTypes verifier = new(Aliased.Intf, fields.Intf, mergeAlternates.Intf, Logger);

    verifier.Verify(UsageAliased, Errors);

    // using AssertionScope scope = new();

    Aliased.Called();
    fields.NotCalled();
    mergeAlternates.NotCalled();
    Errors.ShouldBeEmpty();
  }
}
