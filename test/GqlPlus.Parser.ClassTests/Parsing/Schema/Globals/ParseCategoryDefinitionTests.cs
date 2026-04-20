using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseCategoryDefinitionTests
  : ModifiersClassTestBase
{

  private readonly Parser<IAstTypeRef>.I _typeRefParser;
  private readonly ParseCategoryDefinition _parser;

  public ParseCategoryDefinitionTests()
  {
    ConfigureRepo<IAstTypeRef>(Parsers, out _typeRefParser);
    _parser = new ParseCategoryDefinition(Parsers);
    SetupError<CategoryOutput>();
    SetupPartial<CategoryOutput>(new(default!));
  }

  [Fact]
  public void Parse_ShouldReturnCategoryOutput_WhenValid()
  {
    // Arrange
    ParseOk(_typeRefParser);
    ParseModifiersOk();
    TakeReturns('}', true);

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<CategoryOutput>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenTypeRefFails()
  {
    // Arrange
    ParseError(_typeRefParser);

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenModifiersFail()
  {
    // Arrange
    ParseOk(_typeRefParser);
    ParseModifiersError();

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<CategoryOutput>>();
  }
}
