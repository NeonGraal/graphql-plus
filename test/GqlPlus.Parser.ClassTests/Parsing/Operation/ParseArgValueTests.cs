using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgValueTests
  : ParserClassTestBase
{

  private readonly ParseArgValue _parseArgValue;
  private readonly Parser<IAstFieldKey>.I _fieldKeyParser;
  private readonly Parser<KeyValue<IAstArg>>.I _keyValueParser;
  private readonly Parser<IAstArg>.IA _listParser;
  private readonly Parser<IAstFields<IAstArg>>.I _objectParser;
  private readonly Parser<IAstConstant>.I _constantParser;

  public ParseArgValueTests()
    : base(A.Of<ITokenizer, IOperationContext>())
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstFieldKey>(parsers, out _fieldKeyParser);
    ConfigureRepo<KeyValue<IAstArg>>(parsers, out _keyValueParser);
    ConfigureRepoArray<IAstArg>(parsers, out _listParser);
    ConfigureRepo<IAstFields<IAstArg>>(parsers, out _objectParser);
    ConfigureRepo<IAstConstant>(parsers, out _constantParser);
    _parseArgValue = new ParseArgValue(parsers);

    PrefixReturns('$', OutPass);
    SetupError<IAstArg>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableArgument_WhenVariableIsParsed(string variable)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(variable));

    // Act
    IResult<IAstArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstArg>>()
      .Required().Variable.ShouldBe(variable);
  }

  [Fact]
  public void Parse_ShouldReturnListArgument_WhenListParserSucceeds()
  {
    // Arrange
    ParseOkA(_listParser);

    // Act
    IResult<IAstArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstArg>>()
      .Required().Values.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnObjectArgument_WhenObjectParserSucceeds(string fieldName)
  {
    // Arrange
    ParseOkField(_objectParser, fieldName);

    // Act
    IResult<IAstArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstArg>>()
      .Required().Fields.ShouldNotBeEmpty();
  }

  [Fact]
  public void Parse_ShouldReturnConstantArgument_WhenConstantParserSucceeds()
  {
    // Arrange
    ParseOk(_constantParser);

    // Act
    IResult<IAstArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstArg>>()
      .Required().Constant.ShouldNotBeNull();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenVariableIsMissingAfterDollarSign()
  {
    // Arrange
    PrefixReturns('$', OutFail);

    // Act
    IResult<IAstArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

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
    IResult<IAstArg> result = _parseArgValue.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
