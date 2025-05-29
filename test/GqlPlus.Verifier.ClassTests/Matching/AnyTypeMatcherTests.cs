using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

public class AnyTypeMatcherTests
  : MatcherTestsBase
{
  private readonly List<IMatcher> _matchers = [];
  private readonly AnyTypeMatcher _sut;

  private readonly IMatcher _matcher = For<IMatcher>();
  public AnyTypeMatcherTests()
    => _sut = new AnyTypeMatcher(_matchers);

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingConstraint(string constraint)
  {
    // Arrange
    IGqlpType type = NFor<IGqlpType>(constraint);
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
    IGqlpType type = NFor<IGqlpType>(constraint);
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
    IGqlpType type = NFor<IGqlpType>(constraint);

    // Act
    Action action = () => _sut.Matches(type, constraint, Context);

    // Assert
    action.ShouldThrow<InvalidOperationException>();
  }
}
