using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionSettingTests : ParserClassTestBase
{

  private readonly IParserDefault _defaultParser;
  private readonly ParseOptionSetting _parser;

  public ParseOptionSettingTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoInterface<IParserDefault, IAstConstant>(parsers, out _defaultParser);
    _parser = new ParseOptionSetting(parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseOk(_defaultParser);

    // Act
    IResult<IAstSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchemaSetting>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultEmpty(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseEmpty(_defaultParser);
    SetupError<IAstSchemaSetting>();

    // Act
    IResult<IAstSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultErrors(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseError(_defaultParser);
    SetupError<IAstSchemaSetting>();

    // Act
    IResult<IAstSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IAstSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
