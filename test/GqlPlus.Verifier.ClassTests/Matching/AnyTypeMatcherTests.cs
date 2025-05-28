using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public class AnyTypeMatcherTests
  : SubstituteBase
{
  private readonly List<IMatcher> _matchers = [];
  private readonly AnyTypeMatcher _sut;

  private readonly IMatcher _matcher = For<IMatcher>();
  private readonly IGqlpType _type = For<IGqlpType>();
  private readonly IGqlpType constraint = For<IGqlpType>();
  private readonly Map<IGqlpDescribed> _types = [];
  private readonly TokenMessages _errors = [];
  private readonly UsageContext _context;

  public AnyTypeMatcherTests()
  {
    _sut = new AnyTypeMatcher(_matchers);
    _context = new(_types, _errors);
  }

  [Fact]
  public void Matches_ReturnsTrue_WhenMatchingConstraint()
  {
    // Arrange
    _matcher.ForConstraint(constraint).Returns(true);
    _matcher.MatchesConstraint(_type, constraint, _context).Returns(true);

    _matchers.Add(_matcher);

    // Act
    bool result = _sut.Matches(_type, constraint, _context);

    // Assert
    result.ShouldBeTrue();
  }

  [Fact]
  public void Matches_ReturnsFalse_WhenMatchingConstraintReturnsFalse()
  {
    // Arrange
    _matcher.ForConstraint(constraint).Returns(true);
    _matcher.MatchesConstraint(_type, constraint, _context).Returns(false);

    _matchers.Add(_matcher);

    // Act
    bool result = _sut.Matches(_type, constraint, _context);

    // Assert
    result.ShouldBeFalse();
  }

  [Fact]
  public void Matches_Throws_WhenNoConstraintMatcher()
  {
    // Arrange
    _matcher.ForConstraint(constraint).Returns(false);
    _matchers.Add(_matcher);

    // Act
    Action action = () => _sut.Matches(_type, constraint, _context);

    // Assert
    action.ShouldThrow<InvalidOperationException>()
      .Message.ShouldContain(constraint.Name);
  }

  [Fact]
  public void Matches_Throws_WhenNoMatchers()
  {
    // _matchers is empty

    // Act
    Action action = () => _sut.Matches(_type, constraint, _context);

    // Assert
    action.ShouldThrow<InvalidOperationException>()
      .Message.ShouldContain(constraint.Name);
  }
}
