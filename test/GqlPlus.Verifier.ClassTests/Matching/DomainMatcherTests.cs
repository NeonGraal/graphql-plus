using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

public class DomainMatcherTests
  : MatcherTestsBase
{
  private readonly Matcher<IGqlpEnum>.I _enumMatcher;
  private readonly DomainMatcher _sut;

  public DomainMatcherTests()
  {
    Matcher<IGqlpEnum>.D enumMatcher = MatcherFor(out _enumMatcher);

    _sut = new DomainMatcher(enumMatcher);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingDomainKindDomain(string name, DomainKind kind)
  {
    this.SkipIf(kind == DomainKind.Enum, "Enum kind requires specific label matching logic.");

    // Arrange
    IGqlpDomain type = NFor<IGqlpDomain>(name);
    type.DomainKind.Returns(kind);

    // Act
    bool result = _sut.Matches(type, $"{kind}", Context);

    // Assert
    result.ShouldBeTrue();
  }
}
