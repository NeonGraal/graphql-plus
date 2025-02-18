using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

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

    using AssertionScope scope = new();

    Aliased.Called();
    fields.NotCalled();
    mergeAlternates.NotCalled();
    Errors.Should().BeNullOrEmpty();
  }
}
