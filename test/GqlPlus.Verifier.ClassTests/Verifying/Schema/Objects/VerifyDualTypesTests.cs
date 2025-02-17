using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : UsageVerifierBase<IGqlpDualObject>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IMerge<IGqlpDualField> fields = For<IMerge<IGqlpDualField>>();
    IMerge<IGqlpDualAlternate> mergeAlternates = For<IMerge<IGqlpDualAlternate>>();
    VerifyDualTypes verifier = new(Aliased, fields, mergeAlternates, Logger);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpDualObject[]>(), Errors);
    fields.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpDualField>>());
    mergeAlternates.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpDualAlternate>>());
    Errors.Should().BeNullOrEmpty();
  }
}
