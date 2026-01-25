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

  [Theory, RepeatData]
  public void Parse_ShouldReturnObject_WhenSuccessful(string label)
  {
    // Arrange
    TakeReturns('{', true);
    ParseOk(_fieldParser, new KeyValue<IGqlpConstant>(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>()));
    TakeReturns('}', true);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFields<IGqlpConstant>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyObject_WhenBracesAreMissing(string label)
  {
    // Arrange
    TakeReturns('{', false);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenFieldParsingFails(string label, string error)
  {
    // Arrange
    TakeReturns('{', true);
    ParseError(_fieldParser, error);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenClosingBraceIsMissing(string label)
  {
    // Arrange
    TakeReturns('{', true);
    ParseOk(_fieldParser, new KeyValue<IGqlpConstant>(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>()));
    TakeReturns('}', false);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
