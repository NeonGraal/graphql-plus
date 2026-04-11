namespace GqlPlus.Parsing;

public class ValueListParserTests
  : ParserClassTestBase
{

  private readonly ValueListParser<IAstConstant> _parser;
  private readonly Parser<IAstConstant>.I _valueParser;

  public ValueListParserTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstConstant>(parsers, out _valueParser);
    _parser = new ValueListParser<IAstConstant>(parsers);
    SetupError<IAstConstant>();
  }

  [Fact]
  public void Parse_ShouldReturnList_WhenSuccessful()
  {
    // Arrange
    TakeReturns('[', true);
    ParseOk(_valueParser, AtFor<IAstConstant>());
    TakeReturns(']', true);

    // Act
    IResultArray<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IAstConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyList_WhenBracketsAreMissing()
  {
    // Arrange
    TakeReturns('[', false);

    // Act
    IResultArray<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IAstConstant>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenValueParsingFails(string error)
  {
    // Arrange
    TakeReturns('[', true);
    ParseError(_valueParser, error);

    // Act
    IResultArray<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenClosingBracketIsMissing()
  {
    // Arrange
    TakeReturns('[', true);
    ParseOk(_valueParser, AtFor<IAstConstant>());
    TakeReturns(']', false);

    // Act
    IResultArray<IAstConstant> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IAstConstant>>();
  }
}
