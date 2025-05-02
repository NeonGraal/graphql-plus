namespace GqlPlus.Parsing;

public class ParseFieldKeyTests
  : ParserClassTestBase
{
  private readonly ParseFieldKey _parseFieldKey;

  public ParseFieldKeyTests()
    => _parseFieldKey = new ParseFieldKey();

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenNumberTokenIsParsed()
  {
    // Arrange
    Tokenizer.Number(out decimal number).Returns(OutNumber(42m));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Number.ShouldNotBeNull();
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenStringTokenIsParsed()
  {
    // Arrange
    Tokenizer.String(out string? contents).Returns(OutString("testString"));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Text.ShouldBe("testString");
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenEnumTypeAndLabelAreParsed()
  {
    // Arrange
    Tokenizer.Take('.').Returns(true);
    Tokenizer.Identifier(out string? enumType).Returns(OutString("EnumType"), OutString("EnumLabel"));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().ShouldSatisfyAllConditions(
        f => f.EnumType.ShouldBe("EnumType"),
        f => f.EnumLabel.ShouldBe("EnumLabel")
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue()
  {
    // Arrange
    Tokenizer.Identifier(out string? enumType).Returns(OutString("EnumType"), OutFail);
    Tokenizer.Take('.').Returns(true);
    SetupError<IGqlpFieldKey>("enum value after '.'");

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldContain("enum value after");
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
