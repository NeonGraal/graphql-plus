namespace GqlPlus.Parsing;

public class ValueObjectParserTests
  : ParserClassTestBase
{
  private readonly ValueObjectParser<IGqlpConstant> _parser;
  private readonly Parser<KeyValue<IGqlpConstant>>.I _fieldParser;

  public ValueObjectParserTests()
  {
    Parser<KeyValue<IGqlpConstant>>.D fieldParser = ParserFor(out _fieldParser);
    _parser = new ValueObjectParser<IGqlpConstant>(fieldParser);

    SetupError<IGqlpFields<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnObject_WhenSuccessful()
  {
    // Arrange
    TakeReturns('{', true);
    ParseOk(_fieldParser, new KeyValue<IGqlpConstant>(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>()));
    TakeReturns('}', true);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFields<IGqlpConstant>>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyObject_WhenBracesAreMissing()
  {
    // Arrange
    TakeReturns('{', false);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty<IGqlpFields<IGqlpConstant>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenFieldParsingFails()
  {
    // Arrange
    TakeReturns('{', true);
    ParseError(_fieldParser, "Field parsing error");

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpFields<IGqlpConstant>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenClosingBraceIsMissing()
  {
    // Arrange
    TakeReturns('{', true);
    ParseOk(_fieldParser, new KeyValue<IGqlpConstant>(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>()));
    TakeReturns('}', false);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpFields<IGqlpConstant>>>();
  }
}
