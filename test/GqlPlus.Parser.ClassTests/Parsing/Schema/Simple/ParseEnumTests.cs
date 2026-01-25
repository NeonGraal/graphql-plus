using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumTests
  : DeclarationClassTestBase
{

  private readonly Parser<EnumDefinition>.I _definition;
  private readonly ParseEnum _parser;

  public ParseEnumTests()
  {
    Parser<EnumDefinition>.D definition = ParserFor(out _definition);
    _parser = new ParseEnum(SimpleName, ParamNull, Aliases, OptionNull, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnum_WhenValid(string enumName)
  {
    // Arrange
    NameReturns(enumName);
    ParseOk(_definition, new EnumDefinition());

    // Act
    IResult<IGqlpEnum> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnum>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoName()
    => Check_ShouldReturnError_WhenNoName(_parser);

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenInvalid(string enumName)
  {
    // Arrange
    NameReturns(enumName);
    ParseError(_definition);
    SetupError<IGqlpEnum>();

    // Act
    IResult<IGqlpEnum> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpEnum>>();
  }
}
