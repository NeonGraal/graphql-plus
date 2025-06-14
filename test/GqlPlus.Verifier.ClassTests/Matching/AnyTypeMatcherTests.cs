namespace GqlPlus.Matching;

public class AnyTypeMatcherTests
  : MatcherTestsBase
{
  private readonly List<ITypeMatcher> _matchers = [];
  private readonly AnyTypeMatcher _sut;

  private readonly ITypeMatcher _matcher = A.Of<ITypeMatcher>();
  public AnyTypeMatcherTests()
    => _sut = new AnyTypeMatcher(LoggerFactory, _matchers);

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingConstraint(string constraint)
  {
    // Arrange
    IGqlpType type = A.Named<IGqlpType>(constraint);
    _matcher.MatchesTypeConstraint(type, constraint, Context).Returns(true);

    _matchers.Add(_matcher);

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsFalse_WhenNoConstraintMatcher(string constraint)
  {
    // Arrange
    IGqlpType type = A.Named<IGqlpType>(constraint);
    _matcher.MatchesTypeConstraint(type, constraint, Context).Returns(false);
    _matchers.Add(_matcher);

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_Throws_WhenNoMatchers(string constraint)
  {
    // _matchers is empty
    IGqlpType type = A.Named<IGqlpType>(constraint);

    // Act
    Action action = () => _sut.Matches(type, constraint, Context);

    // Assert
    action.ShouldThrow<InvalidOperationException>();
  }
}
