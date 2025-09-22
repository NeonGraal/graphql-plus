namespace GqlPlus.Matching;

public class AlternateConstraintMatcherTests
  : MatcherTestsBase
{
  private readonly AlternateConstraintMatcher _sut;
  private readonly Matcher<IGqlpType>.I _anyType;

  public AlternateConstraintMatcherTests()
  {
    Matcher<IGqlpType>.D anyType = MatcherFor(out _anyType);

    _sut = new(LoggerFactory, anyType);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingAlternateMember(string name, string constraint)
  {
    IGqlpObject objectType = A.Named<IGqlpObject>(constraint);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(name);
    objectType.Alternates.Returns([alternate]);
    Types[constraint] = objectType;

    IGqlpType type = A.Named<IGqlpType>(name);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingAlternateMemberParent(string constraint, string name, string parent, bool expected)
  {
    this.SkipEqual3(name, constraint, parent);

    IGqlpObject objectType = A.Named<IGqlpObject>(constraint);
    IGqlpObjAlt alternate = A.Named<IGqlpObjAlt>(name);
    objectType.Alternates.Returns([alternate]);
    Types[constraint] = objectType;

    IGqlpType type = A.Named<IGqlpType>(parent);
    _anyType.Matches(type, name, Context).Returns(expected);

    bool result = _sut.MatchesTypeConstraint(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
