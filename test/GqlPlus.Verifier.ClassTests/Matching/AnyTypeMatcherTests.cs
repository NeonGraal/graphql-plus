namespace GqlPlus.Matching;

public class AnyTypeMatcherTests
  : MatcherTestsBase
{
  private readonly List<IMatcher> _matchers = [];
  private readonly AnyTypeMatcher _sut;

  private readonly IMatcher _matcher = For<IMatcher>();
  public AnyTypeMatcherTests()
    => _sut = new AnyTypeMatcher(_matchers);

  [Fact]
  public void Matches_ReturnsTrue_WhenMatchingConstraint()
  {
    // Arrange
    _matcher.MatchesTypeConstraint(Type, Constraint, Context).Returns(true);

    _matchers.Add(_matcher);

    // Act
    bool result = _sut.Matches(Type, Constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Fact]
  public void Matches_ReturnsFalse_WhenNoConstraintMatcher()
  {
    // Arrange
    _matcher.MatchesTypeConstraint(Type, Constraint, Context).Returns(false);
    _matchers.Add(_matcher);

    // Act
    bool result = _sut.Matches(Type, Constraint, Context);

    // Assert
    result.ShouldBeFalse();
  }

  [Fact]
  public void Matches_Throws_WhenNoMatchers()
  {
    // _matchers is empty

    // Act
    Action action = () => _sut.Matches(Type, Constraint, Context);

    // Assert
    action.ShouldThrow<InvalidOperationException>()
      .Message.ShouldContain(Constraint.Name);
  }
}
