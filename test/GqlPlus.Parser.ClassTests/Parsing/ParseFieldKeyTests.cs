namespace GqlPlus.Parsing;

public class ParseFieldKeyTests
  : ParserClassTestBase
{
  private readonly ParseFieldKey _parseFieldKey;

  private readonly Parser<IGqlpEnumValue>.I _parseEnumValue;

  public ParseFieldKeyTests()
  {
    Parser<IGqlpEnumValue>.D parseEnumValue = ParserFor(out _parseEnumValue);
    _parseFieldKey = new ParseFieldKey(parseEnumValue);
    SetupError<IGqlpFieldKey>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenNumberTokenIsParsed(decimal value, string label)
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(OutNumber(value));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Number.ShouldBe(value);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenStringTokenIsParsed(string contents, string label)
  {
    // Arrange
    Tokenizer.String(out string? _).Returns(OutString(contents));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Text.ShouldBe(contents);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenEmptyStringTokenIsParsed(string contents, string label)
  {
    // Arrange
    Tokenizer.String(out string? _).Returns(OutString(contents));

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().Text.ShouldBe(contents);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenEnumValueParsed(string label)
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(false);
    Tokenizer.String(out string? _).Returns(false);
    ParseOk(_parseEnumValue);

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFieldKey>>()
      .Required().EnumValue.ShouldNotBeNull();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue(string label)
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(false);
    Tokenizer.String(out string? _).Returns(false);
    ParseError(_parseEnumValue);

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed(string label)
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(false);
    Tokenizer.String(out string? _).Returns(false);
    ParseEmpty(_parseEnumValue);

    // Act
    IResult<IGqlpFieldKey> result = _parseFieldKey.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
