namespace GqlPlus.Parsing;

public class ParseFieldKeyTests
  : ParserClassTestBase
{

  private readonly ParseFieldKey _parseFieldKey;

  private readonly Parser<IAstEnumValue>.I _parseEnumValue;

  public ParseFieldKeyTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstEnumValue>(parsers, out _parseEnumValue);
    _parseFieldKey = new ParseFieldKey(parsers);
    SetupError<IAstFieldKey>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenNumberTokenIsParsed(decimal value)
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(OutNumber(value));

    // Act
    IResult<IAstFieldKey> result = _parseFieldKey.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstFieldKey>>()
      .Required().Number.ShouldBe(value);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldKeyResult_WhenStringTokenIsParsed(string contents)
  {
    // Arrange
    Tokenizer.String(out string? _).Returns(OutString(contents));

    // Act
    IResult<IAstFieldKey> result = _parseFieldKey.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstFieldKey>>()
      .Required().Text.ShouldBe(contents);
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenEmptyStringTokenIsParsed()
  {
    // Arrange
    Tokenizer.String(out string? _).Returns(OutString(string.Empty));

    // Act
    IResult<IAstFieldKey> result = _parseFieldKey.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstFieldKey>>()
      .Required().Text.ShouldBe(string.Empty);
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenEnumValueParsed()
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(false);
    Tokenizer.String(out string? _).Returns(false);
    ParseOk(_parseEnumValue);

    // Act
    IResult<IAstFieldKey> result = _parseFieldKey.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstFieldKey>>()
      .Required().EnumValue.ShouldNotBeNull();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue()
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(false);
    Tokenizer.String(out string? _).Returns(false);
    ParseError(_parseEnumValue);

    // Act
    IResult<IAstFieldKey> result = _parseFieldKey.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Arrange
    Tokenizer.Number(out decimal _).Returns(false);
    Tokenizer.String(out string? _).Returns(false);
    ParseEmpty(_parseEnumValue);

    // Act
    IResult<IAstFieldKey> result = _parseFieldKey.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
