namespace GqlPlus.Matching;

public class DomainMatcherTests
  : MatcherTestsBase
{
  private readonly Matcher<IGqlpEnum>.I _enumMatcher;
  private readonly DomainMatcher _sut;

  public DomainMatcherTests()
  {
    Matcher<IGqlpEnum>.D enumMatcher = MatcherFor(out _enumMatcher);

    _sut = new DomainMatcher(LoggerFactory, enumMatcher);
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingDomainKindDomain(string name, DomainKind kind)
  {
    this.SkipIf(kind == DomainKind.Enum, "Enum kind requires specific label matching logic.");

    // Arrange
    IGqlpDomain type = A.Domain<IGqlpDomainLabel>(name, kind);

    // Act
    bool result = _sut.Matches(type, $"{kind}", Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumDomain(string domain, string constraint)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainLabel> type = A.DomainEnum(domain, null, constraint, "");

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumParent(string domain, string constraint, string enumName)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainLabel> type = A.DomainEnum(domain, null, enumName, "");

    IGqlpEnum enumType = A.Enum(enumName, []);
    Types[enumName] = enumType;

    _enumMatcher.Matches(enumType, constraint, Context).Returns(true);

    // Act
    bool result = _sut.Matches(type, enumName, Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingLabelDomain(string domain, string constraint, string enumLabel)
  {
    // Arrange
    IGqlpDomain<IGqlpDomainLabel> type = A.DomainEnum(domain, null, "", enumLabel);

    IGqlpEnum enumType = A.Enum(constraint, [enumLabel]);
    EnumValues[enumLabel] = constraint;

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }
}
