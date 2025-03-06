using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema.Objects;

namespace GqlPlus.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : UsageVerifierBase<IGqlpInputObject>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    ForM<IGqlpInputField> fields = new();
    ForM<IGqlpInputAlternate> mergeAlternates = new();
    VerifyInputTypes verifier = new(Aliased.Intf, fields.Intf, mergeAlternates.Intf, Logger);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.Called();
    fields.NotCalled();
    mergeAlternates.NotCalled();
    Errors.Should().BeNullOrEmpty();
  }
}
