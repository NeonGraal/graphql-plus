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
    IGqlpObject objectType = NFor<IGqlpObject>(constraint);
    IGqlpObjAlternate alternate = NFor<IGqlpObjAlternate>(name);
    objectType.Alternates.Returns([alternate]);
    Types[constraint] = objectType;

    IGqlpType type = NFor<IGqlpType>(name);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsExpected_WhenMatchingAlternateMemberParent(string constraint, string name, string parent, bool expected)
  {
    IGqlpObject objectType = NFor<IGqlpObject>(constraint);
    IGqlpObjAlternate alternate = NFor<IGqlpObjAlternate>(name);
    objectType.Alternates.Returns([alternate]);
    Types[constraint] = objectType;

    IGqlpType type = NFor<IGqlpType>(parent);
    _anyType.Matches(type, name, Context).Returns(expected);

    bool result = _sut.Matches(type, constraint, Context);

    result.ShouldBe(expected);
  }
}
