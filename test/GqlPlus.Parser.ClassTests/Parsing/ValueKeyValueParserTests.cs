namespace GqlPlus.Parsing;

public class ValueKeyValueParserTests
  : ParserClassTestBase
{

  private readonly ValueKeyValueParser<IGqlpConstant> _parser;
  private readonly Parser<IGqlpFieldKey>.I _keyParser;
  private readonly Parser<IGqlpConstant>.I _valueParser;

  public ValueKeyValueParserTests()
  {
    Parser<IGqlpFieldKey>.D keyParser = ParserFor(out _keyParser);
    Parser<IGqlpConstant>.D valueParser = ParserFor(out _valueParser);

    _parser = new ValueKeyValueParser<IGqlpConstant>(keyParser, valueParser);

    SetupError<KeyValue<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnKeyValue_WhenSuccessful()
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IGqlpFieldKey>());
    TakeReturns(':', true);
    ParseOk(_valueParser, AtFor<IGqlpConstant>());

    // Act
    IResult<KeyValue<IGqlpConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<KeyValue<IGqlpConstant>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenColonIsMissing()
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IGqlpFieldKey>());
    TakeReturns(':', false);

    // Act
    IResult<KeyValue<IGqlpConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenKeyParsingFails(string error)
  {
    // Arrange
    ParseError(_keyParser, error);

    // Act
    IResult<KeyValue<IGqlpConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch(error);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenValueParsingEmpty()
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IGqlpFieldKey>());
    TakeReturns(':', true);
    ParseEmpty(_valueParser);

    // Act
    IResult<KeyValue<IGqlpConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch("error for KeyValue");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenValueParsingFails(string error)
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IGqlpFieldKey>());
    TakeReturns(':', true);
    ParseError(_valueParser, error);

    // Act
    IResult<KeyValue<IGqlpConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch(error);
  }
}
