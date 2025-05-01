using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgTests
  : ParserClassTestBase
{
  private readonly ParseArg _parseArg;
  private readonly ITokenizer _tokenizer = For<ITokenizer>();
  private readonly Parser<IGqlpFieldKey>.I _fieldKeyParser;
  private readonly Parser<IGqlpArg>.I _argumentParser;

  public ParseArgTests()
  {
    _tokenizer.Error<IGqlpArg>("", "").ReturnsForAnyArgs(new ResultError<IGqlpArg>());
    _tokenizer.Error<IGqlpArg>("", "", null).ReturnsForAnyArgs(new ResultError<IGqlpArg>());

    Parser<IGqlpFieldKey>.D fieldKeyParser = ParserFor(out _fieldKeyParser);
    Parser<IValueParser<IGqlpArg>, IGqlpArg>.D argumentParser = ParserFor<IValueParser<IGqlpArg>, IGqlpArg>(out _argumentParser);

    _parseArg = new ParseArg(fieldKeyParser, argumentParser);
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoOpeningParenthesis()
  {
    // Arrange
    _tokenizer.Take('(').Returns(false);

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeFalse();
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenFieldKeyIsParsed()
  {
    // Arrange
    _tokenizer.Take('(').Returns(true);
    _tokenizer.Take(':').Returns(true);
    _tokenizer.Take(')').Returns(true);

    IGqlpFieldKey fieldKey = AtFor<IGqlpFieldKey>();
    fieldKey.Text.Returns("fieldKey");
    _fieldKeyParser.Parse(_tokenizer, "testLabel").Returns(fieldKey.Ok());

    IGqlpArg arg = AtFor<IGqlpArg>();
    arg.Variable.Returns("arg");
    _argumentParser.Parse(_tokenizer, "Arg").Returns(arg.Ok());

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeTrue();
  }

  [Fact]
  public void Parse_ShouldReturnArgumentResult_WhenNoFieldKeyIsParsed()
  {
    // Arrange
    _tokenizer.Take('(').Returns(true);
    _tokenizer.Take(')').Returns(true);

    IGqlpFieldKey fieldKey = AtFor<IGqlpFieldKey>();
    fieldKey.Text.Returns("fieldKey");
    _fieldKeyParser.Parse(_tokenizer, "testLabel").Returns(fieldKey.Ok());

    IGqlpArg arg = AtFor<IGqlpArg>();
    arg.Variable.Returns("arg");
    _argumentParser.Parse(_tokenizer, "testLabel").Returns(arg.Ok());

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeTrue();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidTokenSequence()
  {
    // Arrange
    _tokenizer.Take('(').Returns(true);
    _tokenizer.Take(')').Returns(false);

    IGqlpFieldKey fieldKey = AtFor<IGqlpFieldKey>();
    fieldKey.Text.Returns("fieldKey");
    _fieldKeyParser.Parse(_tokenizer, "testLabel").Returns(fieldKey.Ok());

    IGqlpArg arg = AtFor<IGqlpArg>();
    arg.Variable.Returns("arg");
    _argumentParser.Parse(_tokenizer, "testLabel").Returns(arg.Ok());

    // Act
    IResult<IGqlpArg> result = _parseArg.Parse(_tokenizer, "testLabel");

    // Assert
    result.ShouldNotBeNull();
    result.IsOk().ShouldBeFalse();
  }
}
