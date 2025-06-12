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

    TAliased item1 = A.Of<TAliased>();
    TAliased item2 = A.Of<TAliased>();

    verifier.Verify([item1, item2], Errors);

    verifier.ShouldSatisfyAllConditions(CheckSimpleVerify);
  }

  [Fact]
  public void Verify_CantMergeGroups_ReturnsErrors()
  {
    GroupedVerifier<TAliased> verifier = NewGroupedVerifier();

    TAliased item1 = A.Of<TAliased>();
    TAliased item2 = A.Of<TAliased>();

    _merger.Intf.CanMerge([]).ReturnsForAnyArgs("Can't merge".MakeMessages());

    verifier.Verify([item1, item2], Errors);

    verifier.ShouldSatisfyAllConditions(
      _merger.Called,
      () => Errors.ShouldNotBeEmpty());
  }

  [Fact]
  public void Verify_CantMergeGroupsWithAliases_ReturnsErrors()
  {
    GroupedVerifier<TAliased> verifier = NewGroupedVerifier();

    TAliased item1 = A.Aliased<TAliased>("name", ["alias1", "alias2"]);
    TAliased item2 = A.Aliased<TAliased>("name", ["alias0", "alias3"]);

    _merger.Intf.CanMerge([]).ReturnsForAnyArgs("Can't merge".MakeMessages());

    verifier.Verify([item1, item2], Errors);

    verifier.ShouldSatisfyAllConditions(
      _merger.Called,
      () => Errors.ShouldNotBeEmpty());
  }

  [Fact]
  public void Verify_CantMergeGroupsWithDuplicateAliases_ReturnsErrors()
  {
    GroupedVerifier<TAliased> verifier = NewGroupedVerifier();

    TAliased item1 = A.Aliased<TAliased>("name1", ["alias1", "alias2"]);
    TAliased item2 = A.Aliased<TAliased>("name2", ["alias0", "alias1"]);

    verifier.Verify([item1, item2], Errors);

    Errors.ShouldNotBeEmpty();
  }

  protected virtual void CheckSimpleVerify()
  {
    _merger.Called();
    Errors.ShouldBeEmpty();
  }

  internal abstract GroupedVerifier<TAliased> NewGroupedVerifier();
}
