using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumTests
  : DeclarationClassTestBase
{

  private readonly Parser<EnumDefinition>.I _definition;
  private readonly ParseEnum _parser;

  public ParseEnumTests()
  {
    ConfigureRepo<EnumDefinition>(Parsers, out _definition);
    _parser = new ParseEnum(Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnum_WhenValid(string enumName)
  {
    // Arrange
    NameReturns(enumName);
    ParseOk(_definition, new EnumDefinition());

    // Act
    IResult<IAstEnum> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstEnum>>();
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
    SetupError<IAstEnum>();

    // Act
    IResult<IAstEnum> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstEnum>>();
  }
}
