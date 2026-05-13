namespace GqlPlus.Parsing;

public class ParseConstantTests
  : ParserClassTestBase
{

  private readonly ParseConstant _parseConstant;

  private readonly IParser<IAstFieldKey> _fieldKeyParser;
  private readonly IParser<KeyValue<IAstConstant>> _keyValueParser;
  private readonly IParserArray<IAstConstant> _listParser;
  private readonly IParser<IAstFields<IAstConstant>> _objectParser;

  public ParseConstantTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepo<KeyValue<IAstConstant>>(parsers, out _keyValueParser);
    ConfigureRepoArray<IAstConstant>(parsers, out _listParser);
    ConfigureRepo<IAstFields<IAstConstant>>(parsers, out _objectParser);
    _parseConstant = new ParseConstant(parsers);
  }

  [Fact]
  public void Parse_ShouldReturnFieldKeyResult_WhenFieldKeyHasValue()
  {
    // Arrange
    ParseOk(_fieldKeyParser);

    // Act
    IResult<IAstConstant> result = _parseConstant.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstConstant>>()
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
    IResult<IAstConstant> result = _parseConstant.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstConstant>>()
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
    IResult<IAstConstant> result = _parseConstant.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstConstant>>()
      .Required().ShouldSatisfyAllConditions(
        x => x.Value.ShouldBeNull(),
        x => x.Values.ShouldBeEmpty(),
        x => x.Fields.ShouldNotBeEmpty()
      );
  }
}
