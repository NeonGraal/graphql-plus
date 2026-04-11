using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgTests
  : ParserClassTestBase
{

  private readonly ParseArg _parseArg;
  private readonly Parser<IAstFieldKey>.I _fieldKeyParser;
  private readonly IValueParser<IAstArg> _argumentParser;

  private readonly IAstFieldKey _fieldKey = AtFor<IAstFieldKey>();
  private readonly IAstArg _arg = AtFor<IAstArg>();

  public ParseArgTests(string fieldKey = "fieldKey", string arg = "arg")
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepoInterface<IValueParser<IAstArg>, IAstArg>(parsers, out _argumentParser);
    _parseArg = new ParseArg(parsers);
    _fieldKey.Text.Returns(fieldKey);
    _arg.Variable.Returns(arg);
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoOpeningParenthesis()
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnFieldValueResult_WhenFieldValueIsParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(')', true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseOk(_argumentParser, _arg);

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnFieldListResult_WhenFieldValueIsParsed(string argLabel)
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(',', true);
    TakeReturns(')', true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseOk(_argumentParser, _arg);
    IAstFields<IAstArg> keyValuePairs = A.Of<IAstFields<IAstArg>>();
    _argumentParser.ParseFieldValues(Tokenizer, argLabel, ')', default!).ReturnsForAnyArgs(keyValuePairs.Ok());

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk>();
  }

  [Fact]
  public void Parse_ShouldReturnFieldValuesResult_WhenFieldValuesAreParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(')', false, true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseOk(_argumentParser, _arg);

    Parser<KeyValue<IAstArg>>.D keyValueDelegate = ParserFor(out Parser<KeyValue<IAstArg>>.I keyValueParser);
    _argumentParser.KeyValueParser.Returns(keyValueDelegate);
    ParseOk(keyValueParser, new KeyValue<IAstArg>(_fieldKey, _arg));

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk>();
  }

  [Fact]
  public void Parse_ShouldReturnFieldValueListResult_WhenFieldValueListIsParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(',', false, true);
    TakeReturns(')', false, true);

    ParseOk(_fieldKeyParser, _fieldKey);
    Parse(_argumentParser, _arg.Ok(), _arg.Ok(), _arg.Empty());

    Parser<KeyValue<IAstArg>>.D keyValueDelegate = ParserFor(out Parser<KeyValue<IAstArg>>.I keyValueParser);
    _argumentParser.KeyValueParser.Returns(keyValueDelegate);
    ParseOk(keyValueParser, new KeyValue<IAstArg>(_fieldKey, _arg));

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenFieldValueErrors()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(')', false, true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseOk(_argumentParser, _arg);

    Parser<KeyValue<IAstArg>>.D keyValueDelegate = ParserFor(out Parser<KeyValue<IAstArg>>.I keyValueParser);
    _argumentParser.KeyValueParser.Returns(keyValueDelegate);
    ParseError(keyValueParser);

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenFieldValueFails()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(')', true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseError(_argumentParser);

    SetupError<IAstArg>();

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnListResult_WhenFieldKeyIsParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', true);

    ParseOk(_fieldKeyParser, _fieldKey);

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk>();
  }

  [Fact]
  public void Parse_ShouldReturnArgumentResult_WhenNoFieldKeyIsParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', true);

    ParseEmpty(_fieldKeyParser);
    ParseOk(_argumentParser, _arg);

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidTokenSequence()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseEmpty(_argumentParser);

    SetupError<IAstArg>();

    // Act
    IResult<IAstArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
