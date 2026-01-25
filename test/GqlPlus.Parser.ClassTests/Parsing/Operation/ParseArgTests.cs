using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgTests
  : ParserClassTestBase
{

  private readonly ParseArg _parseArg;
  private readonly Parser<IGqlpFieldKey>.I _fieldKeyParser;
  private readonly IValueParser<IGqlpArg> _argumentParser;

  private readonly IGqlpFieldKey _fieldKey = AtFor<IGqlpFieldKey>();
  private readonly IGqlpArg _arg = AtFor<IGqlpArg>();

  public ParseArgTests(string fieldKey = "fieldKey", string arg = "arg")
  {
    Parser<IGqlpFieldKey>.D fieldKeyParser = ParserFor(out _fieldKeyParser);
    Parser<IValueParser<IGqlpArg>, IGqlpArg>.D argumentParser = ParserFor<IValueParser<IGqlpArg>, IGqlpArg>(out _argumentParser);

    _parseArg = new ParseArg(fieldKeyParser, argumentParser);

    _fieldKey.Text.Returns(fieldKey);
    _arg.Variable.Returns(arg);
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoOpeningParenthesis()
  {
    // Arrange
    TakeReturns('(', false);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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
    IGqlpFields<IGqlpArg> keyValuePairs = A.Of<IGqlpFields<IGqlpArg>>();
    _argumentParser.ParseFieldValues(Tokenizer, argLabel, ')', default!).ReturnsForAnyArgs(keyValuePairs.Ok());

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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

    Parser<KeyValue<IGqlpArg>>.D keyValueDelegate = ParserFor(out Parser<KeyValue<IGqlpArg>>.I keyValueParser);
    _argumentParser.KeyValueParser.Returns(keyValueDelegate);
    ParseOk(keyValueParser, new KeyValue<IGqlpArg>(_fieldKey, _arg));

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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

    Parser<KeyValue<IGqlpArg>>.D keyValueDelegate = ParserFor(out Parser<KeyValue<IGqlpArg>>.I keyValueParser);
    _argumentParser.KeyValueParser.Returns(keyValueDelegate);
    ParseOk(keyValueParser, new KeyValue<IGqlpArg>(_fieldKey, _arg));

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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

    Parser<KeyValue<IGqlpArg>>.D keyValueDelegate = ParserFor(out Parser<KeyValue<IGqlpArg>>.I keyValueParser);
    _argumentParser.KeyValueParser.Returns(keyValueDelegate);
    ParseError(keyValueParser);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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

    SetupError<IGqlpArg>();

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

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

    SetupError<IGqlpArg>();

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
