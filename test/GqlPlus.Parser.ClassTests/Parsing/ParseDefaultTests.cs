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

  [Fact]
  public void Parse_ShouldReturnParsedResult_WhenEqualsSignIsPresent()
  {
    // Arrange
    TakeReturns('=', true);
    ParseOk(_constantParser);

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, "TestLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenEqualsSignIsNotPresent()
  {
    // Arrange
    TakeReturns('=', false);

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, "TestLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenConstantParserFails()
  {
    // Arrange
    TakeReturns('=', true);
    ParseError(_constantParser, "Default after error");

    // Act
    IResult<IGqlpConstant> result = _parser.Parse(Tokenizer, "TestLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>()
      .Message.Message.ShouldMatch("Default after error");
  }
}
