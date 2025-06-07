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
    IGqlpDomain type = A.Named<IGqlpDomain>(name);
    type.DomainKind.Returns(kind);

    // Act
    bool result = _sut.Matches(type, $"{kind}", Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumDomain(string domain, string constraint)
  {
    // Arrange
    IGqlpDomainLabel typeLabel = A.Of<IGqlpDomainLabel>();
    typeLabel.EnumType.Returns(constraint);

    IGqlpDomain<IGqlpDomainLabel> type = A.Named<IGqlpDomain<IGqlpDomainLabel>>(domain);
    type.DomainKind.Returns(DomainKind.Enum);
    type.Items.Returns([typeLabel]);

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumParent(string domain, string constraint, string enumName)
  {
    // Arrange
    IGqlpDomainLabel typeLabel = A.Of<IGqlpDomainLabel>();
    typeLabel.EnumType.Returns(enumName);

    IGqlpDomain<IGqlpDomainLabel> type = A.Named<IGqlpDomain<IGqlpDomainLabel>>(domain);
    type.DomainKind.Returns(DomainKind.Enum);
    type.Items.Returns([typeLabel]);

    IGqlpEnum enumType = A.Named<IGqlpEnum>(enumName);
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
    IGqlpDomainLabel typeLabel = A.Of<IGqlpDomainLabel>();
    typeLabel.EnumItem.Returns(enumLabel);

    IGqlpDomain<IGqlpDomainLabel> type = A.Named<IGqlpDomain<IGqlpDomainLabel>>(domain);
    type.DomainKind.Returns(DomainKind.Enum);
    type.Items.Returns([typeLabel]);

    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(enumLabel);
    IGqlpEnum enumType = A.Named<IGqlpEnum>(constraint);
    enumType.Items.Returns([label]);

    EnumValues[enumLabel] = constraint;

    // Act
    bool result = _sut.Matches(type, constraint, Context);

    // Assert
    result.ShouldBeTrue();
  }
}
