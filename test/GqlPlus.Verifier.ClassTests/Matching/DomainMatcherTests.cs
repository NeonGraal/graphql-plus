using GqlPlus.Ast.Schema;

namespace GqlPlus.Matching;

public class DomainMatcherTests
  : MatchTestsBase
{
  private readonly Matcher<IAstEnum>.I _enumMatcher;
  private readonly DomainMatcher _sut;

  public DomainMatcherTests()
  {
    Matcher<IAstEnum>.D enumMatcher = MatcherFor(out _enumMatcher);
    MatcherRepo.MatcherFor<IAstEnum>().Returns(enumMatcher);
    _sut = new DomainMatcher(MatcherRepo);
  }

  [Fact]
  public void Matches_ReturnsFalse_WhenMatchingUnknownKind()
  {
    // Arrange
    IAstDomain type = A.Domain<IAstDomainItem>("Unknown", (DomainKind)99).AsDomain;

    // Act
    bool result = _sut.Matches(type, "Unknown", Context);

    // Assert
    result.ShouldBeFalse();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingDomainKindDomain(string name, DomainKind kind)
  {
    this.SkipEqual(kind, DomainKind.Enum, "Enum kind requires specific label matching logic.");

    // Arrange
    IAstDomain type = A.Domain<IAstDomainLabel>(name, kind).AsDomain;

    // Act
    bool result = _sut.Matches(type, $"{kind}", Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumByName(string domain, string constraint)
  {
    // Arrange
    IAstDomain<IAstDomainLabel> type = A.DomainEnum(domain, constraint, "");

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumByMatcher(string domain, string constraint, string enumName)
  {
    // Arrange
    IAstDomain<IAstDomainLabel> type = A.DomainEnum(domain, enumName, "");

    IAstEnum enumType = A.Enum(enumName).AsEnum;
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
    IAstDomain<IAstDomainLabel> type = A.DomainEnum(domain, "", enumLabel);

    IAstEnum enumType = A.Enum(constraint, [enumLabel]);
    EnumValues[enumLabel] = constraint;

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }
}
