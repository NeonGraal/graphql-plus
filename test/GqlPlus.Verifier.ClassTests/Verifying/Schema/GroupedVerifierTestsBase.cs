using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema;

public abstract class GroupedVerifierTestsBase<TAliased>
  : VerifierTestsBase
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

    verifier.ShouldSatisfyAllConditions(CheckSimpleVerify);
  }

  [Fact]
  public void Verify_CantMergeGroups_ReturnsErrors()
  {
    GroupedVerifier<TAliased> verifier = NewGroupedVerifier();

    TAliased item1 = For<TAliased>();
    TAliased item2 = For<TAliased>();

    _merger.Intf.CanMerge([]).ReturnsForAnyArgs(MakeMessages("Can't merge"));

    verifier.Verify([item1, item2], Errors);

    verifier.ShouldSatisfyAllConditions(
      _merger.Called,
      () => Errors.ShouldNotBeEmpty());
  }

  [Fact]
  public void Verify_CantMergeGroupsWithAliases_ReturnsErrors()
  {
    GroupedVerifier<TAliased> verifier = NewGroupedVerifier();

    TAliased item1 = For<TAliased>();
    item1.Aliases.Returns(["alias1", "alias2"]);
    TAliased item2 = For<TAliased>();
    item2.Aliases.Returns(["alias0", "alias3"]);

    _merger.Intf.CanMerge([]).ReturnsForAnyArgs(MakeMessages("Can't merge"));

    verifier.Verify([item1, item2], Errors);

    verifier.ShouldSatisfyAllConditions(
      _merger.Called,
      () => Errors.ShouldNotBeEmpty());
  }

  protected virtual void CheckSimpleVerify()
  {
    _merger.Called();
    Errors.ShouldBeEmpty();
  }

  internal abstract GroupedVerifier<TAliased> NewGroupedVerifier();
}
