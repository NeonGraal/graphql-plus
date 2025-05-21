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
    TakeReturns('(', false);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull()
      .IsOk().ShouldBeFalse();
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenFieldKeyIsParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(':', true);
    TakeReturns(')', true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseOk(_argumentParser, _arg);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull()
      .IsOk().ShouldBeTrue();
  }

  [Fact]
  public void Parse_ShouldReturnArgumentResult_WhenNoFieldKeyIsParsed()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', true);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseEmpty(_argumentParser);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull()
      .IsOk().ShouldBeTrue();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidTokenSequence()
  {
    // Arrange
    TakeReturns('(', true);
    TakeReturns(')', false);

    ParseOk(_fieldKeyParser, _fieldKey);
    ParseEmpty(_argumentParser);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull()
      .IsOk().ShouldBeFalse();
  }
}
