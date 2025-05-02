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
    Parser<IGqlpConstant>.DA listParser = ArrayParserFor(out _listParser);
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
    ParseOkArray(_listParser);

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

  [Fact]
  public void Parse_ShouldReturnObjectResult_WhenListParserFailsAndObjectParserSucceeds()
  {
    // Arrange
    ParseEmptyArray(_listParser);

    IGqlpFields<IGqlpConstant> objectResult = Substitute.For<IGqlpFields<IGqlpConstant>>();
    FieldKeyAst fieldKey = new(AstNulls.At, "testField");
    IGqlpConstant constant = AtFor<IGqlpConstant>();
    Dictionary<IGqlpFieldKey, IGqlpConstant> dict = new() { [fieldKey] = constant };
    objectResult.GetEnumerator().Returns(dict.GetEnumerator());
    _objectParser.Parse(Tokenizer, "testLabel").Returns(objectResult.Ok());

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
