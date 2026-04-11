namespace GqlPlus.Parsing;

public class ParseDefaultTests
  : ParserClassTestBase
{

  private readonly ParseDefault _parser;
  private readonly Parser<IAstConstant>.I _constantParser;

  public ParseDefaultTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstConstant>(parsers, out _constantParser);
    _parser = new ParseDefault(parsers);
  }

  [Fact]
  public void Parse_ShouldReturnParsedResult_WhenEqualsSignIsPresent()
  {
    // Arrange
    TakeReturns('=', true);
    ParseOk(_constantParser);

    // Act
    IResult<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenEqualsSignIsNotPresent()
  {
    // Arrange
    TakeReturns('=', false);

    // Act
    IResult<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenConstantParserFails(string error)
  {
    // Arrange
    TakeReturns('=', true);
    ParseError(_constantParser, error);

    // Act
    IResult<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenConstantParserEmpty()
  {
    // Arrange
    TakeReturns('=', true);
    ParseEmpty(_constantParser);
    SetupError<IAstConstant>();

    // Act
    IResult<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
