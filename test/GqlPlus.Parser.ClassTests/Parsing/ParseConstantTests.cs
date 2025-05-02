namespace GqlPlus.Parsing;

public class ParseConstantTests
  : ParserClassTestBase
{
  private readonly ParseConstant _parseConstant;

  private readonly Parser<IGqlpFieldKey>.I _fieldKeyParser;
  private readonly Parser<KeyValue<IGqlpConstant>>.I _keyValueParser;
  private readonly Parser<IGqlpConstant>.IA _listParser;
  private readonly Parser<IGqlpFields<IGqlpConstant>>.I _objectParser;

  public ParseConstantTests()
  {
    Parser<IGqlpFieldKey>.D fieldKeyParser = ParserFor(out _fieldKeyParser);
    Parser<KeyValue<IGqlpConstant>>.D keyValueParser = ParserFor(out _keyValueParser);
    Parser<IGqlpConstant>.DA listParser = ParserAFor(out _listParser);
    Parser<IGqlpFields<IGqlpConstant>>.D objectParser = ParserFor(out _objectParser);

    _parseConstant = new ParseConstant(fieldKeyParser, keyValueParser, listParser, objectParser);
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenFieldKeyHasValue()
  {
    // Arrange
    ParseOk(_fieldKeyParser);

    // Act
    IResult<IGqlpConstant> result = _parseConstant.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Value.ShouldNotBeNull(),
        x => x.Values.ShouldBeEmpty(),
        x => x.Fields.ShouldBeEmpty()
      );
  }

  [Fact]
  public void Parse_ShouldReturnListResult_WhenListParserSucceeds()
  {
    // Arrange
    ParseOkA(_listParser);

    // Act
    IResult<IGqlpConstant> result = _parseConstant.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Value.ShouldBeNull(),
        x => x.Values.ShouldNotBeEmpty(),
        x => x.Fields.ShouldBeEmpty()
      );
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnObjectResult_WhenListParserFailsAndObjectParserSucceeds(string fieldName)
  {
    // Arrange
    ParseEmptyA(_listParser);

    IGqlpFields<IGqlpConstant> objectResult = Substitute.For<IGqlpFields<IGqlpConstant>>();
    FieldKeyAst fieldKey = new(AstNulls.At, fieldName);
    IGqlpConstant constant = AtFor<IGqlpConstant>();
    Dictionary<IGqlpFieldKey, IGqlpConstant> dict = new() { [fieldKey] = constant };
    objectResult.GetEnumerator().Returns(dict.GetEnumerator());
    ParseOk(_objectParser, objectResult);

    // Act
    IResult<IGqlpConstant> result = _parseConstant.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Value.ShouldBeNull(),
        x => x.Values.ShouldBeEmpty(),
        x => x.Fields.ShouldNotBeEmpty()
      );
  }
}
