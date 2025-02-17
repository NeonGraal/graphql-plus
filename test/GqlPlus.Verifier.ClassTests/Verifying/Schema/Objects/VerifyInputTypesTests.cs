using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : UsageVerifierBase<IGqlpInputObject>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IMerge<IGqlpInputField> fields = For<IMerge<IGqlpInputField>>();
    IMerge<IGqlpInputAlternate> mergeAlternates = For<IMerge<IGqlpInputAlternate>>();
    VerifyInputTypes verifier = new(Aliased, fields, mergeAlternates, Logger);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpInputObject[]>(), Errors);
    fields.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpInputField>>());
    mergeAlternates.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpInputAlternate>>());
    Errors.Should().BeNullOrEmpty();
  }
}
