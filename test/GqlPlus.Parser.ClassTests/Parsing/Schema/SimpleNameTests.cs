namespace GqlPlus.Parsing.Schema;

public class SimpleNameTests
  : ParserClassTestBase
{
  private readonly SimpleName _simpleName = new();

  [Theory, RepeatData]
  public void ParseName_ShouldReturnTrue_WhenIdentifierIsValid(string input)
  {
    // Arrange
    IdentifierReturns(OutString(input));

    // Act
    bool result = _simpleName.ParseName(Tokenizer, out string? name, out TokenAt at);

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
    bool result = _simpleName.ParseName(Tokenizer, out string? name, out TokenAt at);

    // Assert
    name.ShouldSatisfyAllConditions(
      () => result.ShouldBeFalse(),
      () => name.ShouldBeNull());
  }
}
