using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace GqlPlus.Verifying.Schema;

public abstract class GroupedVerifierBase<TAliased>
  : VerifierBase
  where TAliased : class, IGqlpAliased
{
  protected IMerge<TAliased> Merger { get; } = For<IMerge<TAliased>>();
  protected ILoggerFactory Logger { get; } = For<ILoggerFactory>();

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    IVerify<TAliased> definition = VFor<TAliased>();

    AliasedVerifier<TAliased> verifier = NewAliasedVerifier(definition);

    TAliased item1 = For<TAliased>();
    TAliased item2 = For<TAliased>();

    verifier.Verify([item1, item2], Errors);

    using AssertionScope scope = new();

    definition.ReceivedWithAnyArgs().Verify(Arg.Any<TAliased>(), Errors);
    Merger.ReceivedWithAnyArgs().CanMerge(Arg.Any<IEnumerable<TAliased>>());
    Errors.Should().BeNullOrEmpty();
  }

  internal abstract AliasedVerifier<TAliased> NewAliasedVerifier(IVerify<TAliased> definition);
}
