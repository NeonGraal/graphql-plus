using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionSettingTests : ParserClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly IParserDefault _defaultParser;
  private readonly ParseOptionSetting _parser;

  public ParseOptionSettingTests()
  {
    Parser<IParserDefault, IGqlpConstant>.D defaultParser = ParserFor<IParserDefault, IGqlpConstant>(out _defaultParser);

    _parser = new ParseOptionSetting(defaultParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseOk(_defaultParser);

    // Act
    IResult<IGqlpSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaSetting>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultEmpty(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseEmpty(_defaultParser);
    SetupError<IGqlpSchemaSetting>();

    // Act
    IResult<IGqlpSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenDefaultErrors(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseError(_defaultParser);
    SetupError<IGqlpSchemaSetting>();

    // Act
    IResult<IGqlpSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpSchemaSetting> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
