using GqlPlus.Verifying.Schema;

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

  [Theory, RepeatData]
  public void Matches_ReturnsTrue_WhenMatchingEnumDomain(string domain, string constraint)
  {
    // Arrange
    IGqlpDomainLabel typeLabel = For<IGqlpDomainLabel>();
    typeLabel.EnumType.Returns(constraint);

    IGqlpDomain<IGqlpDomainLabel> type = NFor<IGqlpDomain<IGqlpDomainLabel>>(domain);
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
    IGqlpDomainLabel typeLabel = For<IGqlpDomainLabel>();
    typeLabel.EnumType.Returns(enumName);

    IGqlpDomain<IGqlpDomainLabel> type = NFor<IGqlpDomain<IGqlpDomainLabel>>(domain);
    type.DomainKind.Returns(DomainKind.Enum);
    type.Items.Returns([typeLabel]);

    IGqlpEnum enumType = NFor<IGqlpEnum>(enumName);
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
    IGqlpDomainLabel typeLabel = For<IGqlpDomainLabel>();
    typeLabel.EnumItem.Returns(enumLabel);

    IGqlpDomain<IGqlpDomainLabel> type = NFor<IGqlpDomain<IGqlpDomainLabel>>(domain);
    type.DomainKind.Returns(DomainKind.Enum);
    type.Items.Returns([typeLabel]);

    IGqlpEnumLabel label = NFor<IGqlpEnumLabel>(enumLabel);
    IGqlpEnum enumType = NFor<IGqlpEnum>(constraint);
    enumType.Items.Returns([label]);

    Map<string> enumValues = new() { [enumLabel] = constraint };

    EnumContext enumContext = new(Types, Errors, enumValues);

    // Act
    bool result = _sut.Matches(type, constraint, enumContext);

    // Assert
    result.ShouldBeTrue();
  }
}
