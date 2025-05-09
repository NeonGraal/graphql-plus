namespace GqlPlus.Parsing.Schema.Globals;

public class DirectiveNameTests
  : ParserClassTestBase
{
  private readonly DirectiveName _directiveName = new();

  [Theory, RepeatData]
  public void ParseName_ShouldReturnTrue_WhenIdentifierIsValid(string input)
  {
    // Arrange
    PrefixReturns('@', OutStringAt(input), OutFailAt());
    IdentifierReturns(OutString(input));

    // Act
    bool result = _directiveName.ParseName(Tokenizer, out string? name, out TokenAt at);

    // Assert
    name.ShouldSatisfyAllConditions(
      () => result.ShouldBeTrue(),
      () => name.ShouldBe(input));
  }

  [Fact]
  public void ParseName_ShouldReturnFalse_WhenIdentifierIsInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    bool result = _directiveName.ParseName(Tokenizer, out string? name, out TokenAt at);

    // Assert
    name.ShouldSatisfyAllConditions(
      () => result.ShouldBeFalse(),
      () => name.ShouldBeNull());
  }
}
