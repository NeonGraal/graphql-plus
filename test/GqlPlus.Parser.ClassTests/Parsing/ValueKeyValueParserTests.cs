namespace GqlPlus.Parsing;

public class ValueKeyValueParserTests
  : ParserClassTestBase
{

  private readonly ValueKeyValueParser<IAstConstant> _parser;
  private readonly Parser<IAstFieldKey>.I _keyParser;
  private readonly Parser<IAstConstant>.I _valueParser;

  public ValueKeyValueParserTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstFieldKey>(parsers, out _keyParser);
    ConfigureRepo<IAstConstant>(parsers, out _valueParser);
    _parser = new ValueKeyValueParser<IAstConstant>(parsers);
    SetupError<KeyValue<IAstConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnKeyValue_WhenSuccessful()
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IAstFieldKey>());
    TakeReturns(':', true);
    ParseOk(_valueParser, AtFor<IAstConstant>());

    // Act
    IResult<KeyValue<IAstConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<KeyValue<IAstConstant>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenColonIsMissing()
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IAstFieldKey>());
    TakeReturns(':', false);

    // Act
    IResult<KeyValue<IAstConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenKeyParsingFails(string error)
  {
    // Arrange
    ParseError(_keyParser, error);

    // Act
    IResult<KeyValue<IAstConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch(error);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenValueParsingEmpty()
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IAstFieldKey>());
    TakeReturns(':', true);
    ParseEmpty(_valueParser);

    // Act
    IResult<KeyValue<IAstConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch("error for KeyValue");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenValueParsingFails(string error)
  {
    // Arrange
    ParseOk(_keyParser, AtFor<IAstFieldKey>());
    TakeReturns(':', true);
    ParseError(_valueParser, error);

    // Act
    IResult<KeyValue<IAstConstant>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch(error);
  }
}
