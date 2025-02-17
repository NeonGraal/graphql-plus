using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumTypesTests
  : UsageVerifierBase<IGqlpEnum>
{
  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    IMerge<IGqlpEnumItem> mergeMembers = For<IMerge<IGqlpEnumItem>>();
    VerifyEnumTypes verifier = new(Aliased, mergeMembers);

    verifier.Verify(UsageAliased, Errors);

    using AssertionScope scope = new();

    Aliased.ReceivedWithAnyArgs().Verify(Arg.Any<IGqlpEnum[]>(), Errors);
    mergeMembers.DidNotReceiveWithAnyArgs().CanMerge(Arg.Any<IEnumerable<IGqlpEnumItem>>());
    Errors.Should().BeNullOrEmpty();
  }
}
