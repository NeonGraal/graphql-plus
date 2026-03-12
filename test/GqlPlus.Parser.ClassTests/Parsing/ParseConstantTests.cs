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
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IGqlpFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepo<KeyValue<IGqlpConstant>>(parsers, out _keyValueParser);
    ConfigureRepoArray<IGqlpConstant>(parsers, out _listParser);
    ConfigureRepo<IGqlpFields<IGqlpConstant>>(parsers, out _objectParser);
    _parseConstant = new ParseConstant(parsers);
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenFieldKeyHasValue()
  {
    // Arrange
    ParseOk(_fieldKeyParser);

    // Act
    IResult<IGqlpConstant> result = _parseConstant.Parse(Tokenizer, TestLabel);

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
    IResult<IGqlpConstant> result = _parseConstant.Parse(Tokenizer, TestLabel);

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
    ParseOkField(_objectParser, fieldName);

    // Act
    IResult<IGqlpConstant> result = _parseConstant.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpConstant>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Value.ShouldBeNull(),
        x => x.Values.ShouldBeEmpty(),
        x => x.Fields.ShouldNotBeEmpty()
      );
  }
}
