using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseCategoryDefinitionTests
  : ModifiersClassTestBase
{
  private readonly Parser<IGqlpTypeRef>.I _typeRefParser;
  private readonly ParseCategoryDefinition _parser;

  public ParseCategoryDefinitionTests()
  {
    Parser<IGqlpTypeRef>.D typeRefParser = ParserFor(out _typeRefParser);

    _parser = new ParseCategoryDefinition(typeRefParser, Modifiers);

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
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<CategoryOutput>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenTypeRefFails()
  {
    // Arrange
    ParseError(_typeRefParser);

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, "testLabel");

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
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<CategoryOutput>>();
  }
}
