namespace GqlPlus.Parsing;

public class ValueListParserTests
  : ParserClassTestBase
{
  private readonly ValueListParser<IGqlpConstant> _parser;
  private readonly Parser<IGqlpConstant>.I _valueParser;

  public ValueListParserTests()
  {
    Parser<IGqlpConstant>.D valueParser = ParserFor(out _valueParser);
    _parser = new ValueListParser<IGqlpConstant>(valueParser);

    SetupError<IGqlpConstant>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnList_WhenSuccessful(string label)
  {
    // Arrange
    TakeReturns('[', true);
    ParseOk(_valueParser, AtFor<IGqlpConstant>());
    TakeReturns(']', true);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpConstant>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyList_WhenBracketsAreMissing(string label)
  {
    // Arrange
    TakeReturns('[', false);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayEmpty<IGqlpConstant>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenValueParsingFails(string label, string error)
  {
    // Arrange
    TakeReturns('[', true);
    ParseError(_valueParser, error);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenClosingBracketIsMissing(string label)
  {
    // Arrange
    TakeReturns('[', true);
    ParseOk(_valueParser, AtFor<IGqlpConstant>());
    TakeReturns(']', false);

    // Act
    IResultArray<IGqlpConstant> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultArrayError<IGqlpConstant>>();
  }
}
