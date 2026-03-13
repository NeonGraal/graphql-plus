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
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IGqlpFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepo<KeyValue<IGqlpConstant>>(parsers, out _keyValueParser);
    ConfigureRepoArray<IGqlpConstant>(parsers, out _listParser);
    ConfigureRepo<IGqlpFields<IGqlpConstant>>(parsers, out _objectParser);

    _valueParser = new TestValueParser(parsers);

    SetupError<IGqlpConstant>();
    SetupError<IGqlpFields<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnParsedValue_WhenSuccessful()
  {
    // Arrange
    ParseOkA(_listParser);

    // Act
    IResult<IGqlpConstant> result = _valueParser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParsingFails()
  {
    // Arrange
    ParseErrorA(_listParser);

    // Act
    IResult<IGqlpConstant> result = _valueParser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void ParseFieldValues_ShouldReturnFields_WhenSuccessful()
  {
    // Arrange
    FieldsAst<IGqlpConstant> fields = new(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>());
    KeyValue<IGqlpConstant> keyValue = new(AtFor<IGqlpFieldKey>(), AtFor<IGqlpConstant>());
    ParseOk(_keyValueParser, keyValue);
    TakeReturns('}', false, true);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _valueParser.ParseFieldValues(Tokenizer, TestLabel, '}', fields);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpFields<IGqlpConstant>>>();
  }

  [Theory, RepeatData]
  public void ParseFieldValues_ShouldReturnError_WhenFieldParsingFails(string error)
  {
    // Arrange
    ParseError(_keyValueParser, error);

    // Act
    IResult<IGqlpFields<IGqlpConstant>> result = _valueParser.ParseFieldValues(Tokenizer, TestLabel, '}', new FieldsAst<IGqlpConstant>());

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  private sealed class TestValueParser(
    IParserRepository parsers
  ) : ValueParser<IGqlpConstant>(parsers)
  {
    protected override Func<IGqlpFields<IGqlpConstant>, IGqlpConstant> NewFields(ITokenAt at)
      => fields => new ConstantAst(at, fields);
    protected override Func<IEnumerable<IGqlpConstant>, IGqlpConstant> NewList(ITokenAt at)
      => list => new ConstantAst(at, list);
  }
}
