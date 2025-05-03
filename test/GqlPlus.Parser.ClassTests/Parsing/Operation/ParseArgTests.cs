using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgTests
  : ParserClassTestBase
{
  private readonly ParseArg _parseArg;
  private readonly Parser<IGqlpFieldKey>.I _fieldKeyParser;
  private readonly Parser<IGqlpArg>.I _argumentParser;

  private readonly IGqlpFieldKey _fieldKey = AtFor<IGqlpFieldKey>();
  private readonly IGqlpArg _arg = AtFor<IGqlpArg>();

  public ParseArgTests()
  {
    Parser<IGqlpFieldKey>.D fieldKeyParser = ParserFor(out _fieldKeyParser);
    Parser<IValueParser<IGqlpArg>, IGqlpArg>.D argumentParser = ParserFor<IValueParser<IGqlpArg>, IGqlpArg>(out _argumentParser);

    _parseArg = new ParseArg(fieldKeyParser, argumentParser);

    _fieldKey.Text.Returns("fieldKey");
    _arg.Variable.Returns("arg");
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoOpeningParenthesis()
  {
    // Arrange
    Tokenizer.Take('(').Returns(false);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeFalse();
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenFieldKeyIsParsed()
  {
    // Arrange
    Tokenizer.Take('(').Returns(true);
    Tokenizer.Take(':').Returns(true);
    Tokenizer.Take(')').Returns(true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseOk(_argumentParser, _arg);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeTrue();
  }

  [Fact]
  public void Parse_ShouldReturnArgumentResult_WhenNoFieldKeyIsParsed()
  {
    // Arrange
    Tokenizer.Take('(').Returns(true);
    Tokenizer.Take(')').Returns(true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseEmpty(_argumentParser);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeTrue();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidTokenSequence()
  {
    // Arrange
    Tokenizer.Take('(').Returns(true);
    Tokenizer.Take(')').Returns(false);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseEmpty(_argumentParser);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeFalse();
  }
}
