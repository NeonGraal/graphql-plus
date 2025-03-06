using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Schema;

public abstract class GroupedVerifierBase<TAliased>
  : VerifierBase
  where TAliased : class, IGqlpAliased
{
  private readonly ForM<TAliased> _merger = new();
  internal IMerge<TAliased> Merger => _merger.Intf;

  [Fact]
  public void Verify_CallsVerifierAndMergerWithoutErrors()
  {
    GroupedVerifier<TAliased> verifier = NewGroupedVerifier();

    TAliased item1 = For<TAliased>();
    TAliased item2 = For<TAliased>();

    verifier.Verify([item1, item2], Errors);

    using AssertionScope scope = new();
    CheckSimpleVerify();
  }

  protected virtual void CheckSimpleVerify()
  {
    _merger.Called();
    Errors.Should().BeNullOrEmpty();
  }

  internal abstract GroupedVerifier<TAliased> NewGroupedVerifier();
}
