using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionDefinitionTests
  : ParserClassTestBase
{

  private readonly Parser<IAstSchemaSetting>.I _settingParser;
  private readonly ParseOptionDefinition _parser;

  public ParseOptionDefinitionTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstSchemaSetting>(parsers, out _settingParser);
    _parser = new ParseOptionDefinition(parsers);
    SetupError<OptionDefinition>();
    TakeReturns('}', false, true);
  }

  [Fact]
  public void Parse_ShouldReturnOptionDefinition_WhenValid()
  {
    // Arrange
    ParseOk(_settingParser);

    // Act
    IResult<OptionDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<OptionDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenSettingsFail()
  {
    // Arrange
    ParseError(_settingParser);

    // Act
    IResult<OptionDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<OptionDefinition>>();
  }
}
