namespace GqlPlus.Parsing.Schema.Globals;

public class CategoryNameTests
  : ParserClassTestBase
{
  private readonly CategoryName _categoryName = new();

  [Theory, RepeatData]
  public void ParseName_ShouldReturnTrue_WhenIdentifierIsValid(string input)
  {
    // Arrange
    IdentifierReturns(OutString(input));

    // Act
    bool result = _categoryName.ParseName(Tokenizer, out string? name, out TokenAt at);

    // Assert
    name.ShouldSatisfyAllConditions(
      () => result.ShouldBeTrue(),
      () => name.ShouldBe(input));
  }

  [Fact]
  public void ParseName_ShouldReturnTrue_WhenIdentifierIsInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    bool result = _categoryName.ParseName(Tokenizer, out string? name, out TokenAt at);

    // Assert
    name.ShouldSatisfyAllConditions(
      () => result.ShouldBeTrue(),
      () => name.ShouldBe(string.Empty));
  }
}
