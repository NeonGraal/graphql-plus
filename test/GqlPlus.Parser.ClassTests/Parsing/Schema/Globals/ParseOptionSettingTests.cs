using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionSettingTests : ParserClassTestBase
{
  private readonly IParserDefault _defaultParser;
  private readonly ParseOptionSetting _parser;

  public ParseOptionSettingTests()
  {
    Parser<IParserDefault, IGqlpConstant>.D defaultParser = ParserFor<IParserDefault, IGqlpConstant>(out _defaultParser);

    _parser = new ParseOptionSetting(defaultParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOptionSetting_WhenValid(string setting)
  {
    // Arrange
    IdentifierReturns(OutString(setting));
    ParseOk(_defaultParser);

    // Act
    IResult<IGqlpSchemaSetting> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaSetting>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpSchemaSetting> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
