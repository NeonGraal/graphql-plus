using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : UsageVerifierBase<IGqlpOutputObject>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IMerge<IGqlpOutputField> fields = For<IMerge<IGqlpOutputField>>();
    IMerge<IGqlpOutputAlternate> mergeAlternates = For<IMerge<IGqlpOutputAlternate>>();
    VerifyOutputTypes verifier = new(Aliased, fields, mergeAlternates, Logger);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpOutputObject[]>(), Errors);
    fields.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpOutputField>>());
    mergeAlternates.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpOutputAlternate>>());
    Errors.Should().BeNullOrEmpty();
  }
}
