namespace GqlPlus.Parsing;

public class ParseDefaultTests
  : ParserClassTestBase
{
  private readonly ParseDefault _parser;
  private readonly Parser<IGqlpConstant>.I _constantParser;

  public ParseDefaultTests()
  {
    Parser<IGqlpConstant>.D constantParser = ParserFor(out _constantParser);
    _parser = new ParseDefault(constantParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParsedResult_WhenEqualsSignIsPresent(string label)
  {
    // Arrange
    TakeReturns('=', true);
    ParseOk(_constantParser);

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyResult_WhenEqualsSignIsNotPresent(string label)
  {
    // Arrange
    TakeReturns('=', false);

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenConstantParserFails(string label, string error)
  {
    // Arrange
    TakeReturns('=', true);
    ParseError(_constantParser, error);

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenConstantParserEmpty(string label)
  {
    // Arrange
    TakeReturns('=', true);
    ParseEmpty(_constantParser);
    SetupError<IGqlpConstant>();

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
