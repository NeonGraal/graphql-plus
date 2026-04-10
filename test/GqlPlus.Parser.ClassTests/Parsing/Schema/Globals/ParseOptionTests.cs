using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionTests
  : DeclarationClassTestBase
{

  private readonly ParseOption _parser;
  private readonly Parser<OptionDefinition>.I _definition;

  public ParseOptionTests()
  {
    ConfigureRepo<OptionDefinition>(Parsers, out _definition);
    _parser = new ParseOption(Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOption_WhenValid(string option)
  {
    // Arrange
    NameReturns(option);
    ParseOk(_definition, new OptionDefinition());

    // Act
    IResult<IAstSchemaOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchemaOption>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalid(string option)
  {
    // Arrange
    NameReturns(option);
    SetupError<IAstSchemaOption>();

    // Act
    IResult<IAstSchemaOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstSchemaOption>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoName()
    => Check_ShouldReturnError_WhenNoName(_parser);
}
