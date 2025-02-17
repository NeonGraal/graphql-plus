using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionTypesTests
  : UsageVerifierBase<IGqlpUnion>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IMerge<IGqlpUnionItem> mergeMembers = For<IMerge<IGqlpUnionItem>>();
    VerifyUnionTypes verifier = new(Aliased, mergeMembers);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpUnion[]>(), Errors);
    mergeMembers.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpUnionItem>>());
    Errors.Should().BeNullOrEmpty();
  }
}
