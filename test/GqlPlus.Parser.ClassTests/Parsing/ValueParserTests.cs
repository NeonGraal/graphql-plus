namespace GqlPlus.Parsing;

public class ValueParserTests
  : ParserClassTestBase
{
  private readonly ValueParser<IGqlpConstant> _valueParser;
  private readonly Parser<IGqlpFieldKey>.I _fieldKeyParser;
  private readonly Parser<KeyValue<IGqlpConstant>>.I _keyValueParser;
  private readonly Parser<IGqlpConstant>.IA _listParser;
  private readonly Parser<IGqlpFields<IGqlpConstant>>.I _objectParser;

  public ValueParserTests()
  {
    Parser<IGqlpFieldKey>.D fieldKeyParser = ParserFor(out _fieldKeyParser);
    Parser<KeyValue<IGqlpConstant>>.D keyValueParser = ParserFor(out _keyValueParser);
    Parser<IGqlpConstant>.DA listParser = ParserAFor(out _listParser);
    Parser<IGqlpFields<IGqlpConstant>>.D objectParser = ParserFor(out _objectParser);

    _valueParser = new TestValueParser(fieldKeyParser, keyValueParser, listParser, objectParser);

    SetupError<IGqlpConstant>();
    SetupError<IGqlpFields<IGqlpConstant>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParsedValue_WhenSuccessful(string label)
  {
    // Arrange
    ParseOkA(_listParser);

    // Act
    IResult<IGqlpConstant> result = _valueParser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParsingFails(string label)
  {
    // Arrange
    ParseErrorA(_listParser);

    // Act
    IResult<IGqlpConstant> result = _valueParser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void ParseFieldValues_ShouldReturnFields_WhenSuccessful(string label)
  {
    // Arrange
    FieldsAst<IGqlpConstant> fields = new(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>());
    KeyValue<IGqlpConstant> keyValue = new(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>());
    ParseOk(_keyValueParser, keyValue);
    TakeReturns('}', false, true);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _valueParser.ParseFieldValues(Tokenizer, label, '}', fields);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFields<IGqlpConstant>>>();
  }

  [Theory, RepeatData]
  public void ParseFieldValues_ShouldReturnError_WhenFieldParsingFails(string label, string error)
  {
    // Arrange
    ParseError(_keyValueParser, error);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _valueParser.ParseFieldValues(Tokenizer, label, '}', new FieldsAst<IGqlpConstant>());

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  private sealed class TestValueParser(
    Parser<IGqlpFieldKey>.D fieldKey,
    Parser<KeyValue<IGqlpConstant>>.D keyValueParser,
    Parser<IGqlpConstant>.DA listParser,
    Parser<IGqlpFields<IGqlpConstant>>.D objectParser
  ) : ValueParser<IGqlpConstant>(fieldKey, keyValueParser, listParser, objectParser)
  {
    protected override Func<IGqlpFields<IGqlpConstant>, IGqlpConstant> NewFields(ITokenAt at)
      => fields => new ConstantAst(at, fields);
    protected override Func<IEnumerable<IGqlpConstant>, IGqlpConstant> NewList(ITokenAt at)
      => list => new ConstantAst(at, list);
  }
}
