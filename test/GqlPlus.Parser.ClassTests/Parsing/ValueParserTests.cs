namespace GqlPlus.Parsing;

public class ValueParserTests
  : ParserClassTestBase
{

  private readonly ValueParser<IAstConstant> _valueParser;
  private readonly Parser<IAstFieldKey>.I _fieldKeyParser;
  private readonly Parser<KeyValue<IAstConstant>>.I _keyValueParser;
  private readonly Parser<IAstConstant>.IA _listParser;
  private readonly Parser<IAstFields<IAstConstant>>.I _objectParser;

  public ValueParserTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepo<KeyValue<IAstConstant>>(parsers, out _keyValueParser);
    ConfigureRepoArray<IAstConstant>(parsers, out _listParser);
    ConfigureRepo<IAstFields<IAstConstant>>(parsers, out _objectParser);

    _valueParser = new TestValueParser(parsers);

    SetupError<IAstConstant>();
    SetupError<IAstFields<IAstConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnParsedValue_WhenSuccessful()
  {
    // Arrange
    ParseOkA(_listParser);

    // Act
    IResult<IAstConstant> result = _valueParser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstConstant>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParsingFails()
  {
    // Arrange
    ParseErrorA(_listParser);

    // Act
    IResult<IAstConstant> result = _valueParser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void ParseFieldValues_ShouldReturnFields_WhenSuccessful()
  {
    // Arrange
    FieldsAst<IAstConstant> fields = new(AtFor<IAstFieldKey>(), AtFor<IAstConstant>());
    KeyValue<IAstConstant> keyValue = new(AtFor<IAstFieldKey>(), AtFor<IAstConstant>());
    ParseOk(_keyValueParser, keyValue);
    TakeReturns('}', false, true);

    // Act
    IResult<IAstFields<IAstConstant>> result = _valueParser.ParseFieldValues(Tokenizer, TestLabel, '}', fields);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstFields<IAstConstant>>>();
  }

  [Theory, RepeatData]
  public void ParseFieldValues_ShouldReturnError_WhenFieldParsingFails(string error)
  {
    // Arrange
    ParseError(_keyValueParser, error);

    // Act
    IResult<IAstFields<IAstConstant>> result = _valueParser.ParseFieldValues(Tokenizer, TestLabel, '}', new FieldsAst<IAstConstant>());

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  private sealed class TestValueParser(
    IParserRepository parsers
  ) : ValueParser<IAstConstant>(parsers)
  {
    protected override Func<IAstFields<IAstConstant>, IAstConstant> NewFields(ITokenAt at)
      => fields => new ConstantAst(at, fields);
    protected override Func<IEnumerable<IAstConstant>, IAstConstant> NewList(ITokenAt at)
      => list => new ConstantAst(at, list);
  }
}
