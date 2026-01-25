using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseOptionTests
  : DeclarationClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly ParseOption _parser;
  private readonly Parser<OptionDefinition>.I _definition;

  public ParseOptionTests()
  {
    Parser<OptionDefinition>.D definition = ParserFor(out _definition);

    _parser = new ParseOption(SimpleName, ParamNull, Aliases, OptionNull, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOption_WhenValid(string option)
  {
    // Arrange
    NameReturns(option);
    ParseOk(_definition, new OptionDefinition());

    // Act
    IResult<IGqlpSchemaOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchemaOption>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalid(string option)
  {
    // Arrange
    NameReturns(option);
    SetupError<IGqlpSchemaOption>();

    // Act
    IResult<IGqlpSchemaOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpSchemaOption>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoName()
    => Check_ShouldReturnError_WhenNoName(_parser);
}
