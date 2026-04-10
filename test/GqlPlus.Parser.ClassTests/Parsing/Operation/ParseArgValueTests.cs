using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgValueTests
  : ParserClassTestBase
{

  private readonly ParseArgValue _parseArgValue;
  private readonly Parser<IAstFieldKey>.I _fieldKeyParser;
  private readonly Parser<KeyValue<IGqlpArg>>.I _keyValueParser;
  private readonly Parser<IGqlpArg>.IA _listParser;
  private readonly Parser<IAstFields<IGqlpArg>>.I _objectParser;
  private readonly Parser<IAstConstant>.I _constantParser;

  public ParseArgValueTests()
    : base(A.Of<ITokenizer, IOperationContext>())
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepo<KeyValue<IGqlpArg>>(parsers, out _keyValueParser);
    ConfigureRepoArray<IGqlpArg>(parsers, out _listParser);
    ConfigureRepo<IAstFields<IGqlpArg>>(parsers, out _objectParser);
    ConfigureRepo<IAstConstant>(parsers, out _constantParser);
    _parseArgValue = new ParseArgValue(parsers);

    PrefixReturns('$', OutPass);
    SetupError<IGqlpArg>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableArgument_WhenVariableIsParsed(string variable)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variable));

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpArg>>()
      .Required().Variable.ShouldBe(variable);
  }

  [Fact]
  public void Parse_ShouldReturnListArgument_WhenListParserSucceeds()
  {
    // Arrange
    ParseOkA(_listParser);

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpArg>>()
      .Required().Values.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnObjectArgument_WhenObjectParserSucceeds(string fieldName)
  {
    // Arrange
    ParseOkField(_objectParser, fieldName);

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpArg>>()
      .Required().Fields.ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnConstantArgument_WhenConstantParserSucceeds()
  {
    // Arrange
    ParseOk(_constantParser);

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpArg>>()
      .Required().Constant.ShouldNotBeNull();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenVariableIsMissingAfterDollarSign()
  {
    // Arrange
    PrefixReturns('$', OutFail);

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Arrange
    ParseEmptyA(_listParser);
    ParseEmpty(_objectParser);
    ParseEmpty(_constantParser);

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
