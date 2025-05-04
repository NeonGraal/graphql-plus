namespace GqlPlus.Parsing;

public class ParseFieldKeyTests
  : ParserClassTestBase
{
  private readonly ParseFieldKey _parseFieldKey;

  public ParseFieldKeyTests()
    => _parseFieldKey = new ParseFieldKey();

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenNumberTokenIsParsed(decimal value)
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(OutNumber(value));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Number.ShouldBe(value);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenStringTokenIsParsed(string contents)
  {
    // Arrange
    Tokenizer.String(out string? _).Returns(OutString(contents));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Text.ShouldBe(contents);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenEnumTypeAndLabelAreParsed(string enumType, string enumLabel)
  {
    // Arrange
    TakeReturns('.', true);
    IdentifierReturns(OutString(enumType), OutString(enumLabel));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().ShouldSatisfyAllConditions(
        f => f.EnumType.ShouldBe(enumType),
        f => f.EnumLabel.ShouldBe(enumLabel)
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue(string enumType)
  {
    // Arrange
    IdentifierReturns(OutString(enumType), OutFail);
    TakeReturns('.', true);
    SetupError<IGqlpFieldKey>();

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
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
