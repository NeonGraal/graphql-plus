namespace GqlPlus.Matching;

public class UnionConstraintMatcherTests
  : MatcherTestsBase
{
  private readonly UnionConstraintMatcher _sut;
  private readonly Matcher<IGqlpType>.I _anyType;

  public UnionConstraintMatcherTests()
  {
    Matcher<IGqlpType>.D anyType = MatcherFor(out _anyType);

    _sut = new(LoggerFactory, anyType);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingUnionMember(string name, string constraint)
  {
    IGqlpUnion union = A.Union(constraint, "", name);
    Types[constraint] = union;

    IGqlpType type = A.Named<IGqlpType>(name);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingUnionMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqual(name, parent);

    IGqlpUnion union = A.Union(constraint, "", name);
    Types[constraint] = union;

    IGqlpType type = A.Named<IGqlpType>(parent);
    _anyType.Matches(type, name, Context).Returns(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
