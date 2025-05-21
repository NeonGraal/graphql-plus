using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionDefinitionTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpSchemaSetting>.I _settingParser;
  private readonly ParseOptionDefinition _parser;

  public ParseOptionDefinitionTests()
  {
    Parser<IGqlpSchemaSetting>.D settingParser = ParserFor(out _settingParser);
    _parser = new ParseOptionDefinition(settingParser);
    SetupError<OptionDefinition>();
    TakeReturns('}', false, true, false);
  }

  [Fact]
  public void Parse_ShouldReturnOptionDefinition_WhenValid()
  {
    // Arrange
    ParseOk(_settingParser);

    // Act
    IResult<OptionDefinition> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<OptionDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenSettingsFail()
  {
    // Arrange
    ParseError(_settingParser);

    // Act
    IResult<OptionDefinition> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OptionDefinition>>();
  }
}
