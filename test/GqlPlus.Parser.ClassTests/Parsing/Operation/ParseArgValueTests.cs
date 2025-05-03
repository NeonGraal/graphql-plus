using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseArgValueTests
  : ParserClassTestBase
{
  private readonly ParseArgValue _parseArgValue;
  private readonly Parser<IGqlpFieldKey>.I _fieldKeyParser;
  private readonly Parser<KeyValue<IGqlpArg>>.I _keyValueParser;
  private readonly Parser<IGqlpArg>.IA _listParser;
  private readonly Parser<IGqlpFields<IGqlpArg>>.I _objectParser;
  private readonly Parser<IGqlpConstant>.I _constantParser;

  public ParseArgValueTests()
  {
    Parser<IGqlpFieldKey>.D fieldKeyParser = ParserFor(out _fieldKeyParser);
    Parser<KeyValue<IGqlpArg>>.D keyValueParser = ParserFor(out _keyValueParser);
    Parser<IGqlpArg>.DA listParser = ParserAFor(out _listParser);
    Parser<IGqlpFields<IGqlpArg>>.D objectParser = ParserFor(out _objectParser);
    Parser<IGqlpConstant>.D constantParser = ParserFor(out _constantParser);

    _parseArgValue = new ParseArgValue(fieldKeyParser, keyValueParser, listParser, objectParser, constantParser);
    Tokenizer.Prefix('$', out string? _, out TokenAt _).Returns(true);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableArgument_WhenVariableIsParsed(string variable)
  {
    // Arrange
    Tokenizer.Prefix('$', out string? _, out TokenAt _).Returns(OutStringAt(variable));

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, "testLabel");

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
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, "testLabel");

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
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, "testLabel");

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
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpArg>>()
      .Required().Constant.ShouldNotBeNull();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenVariableIsMissingAfterDollarSign()
  {
    // Arrange
    Tokenizer.Prefix('$', out string? _, out TokenAt _).Returns(false);
    SetupError<IGqlpArg>("identifier after '$'");

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Arrange
    ParseEmptyA(_listParser);
    ParseEmpty(_objectParser);
    ParseEmpty(_constantParser);

    // Act
    IResult<IGqlpArg> result = _parseArgValue.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty<IGqlpArg>>();
  }
}
