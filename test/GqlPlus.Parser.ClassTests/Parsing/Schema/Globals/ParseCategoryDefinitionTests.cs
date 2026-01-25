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

  [Theory, RepeatData]
  public void Parse_ShouldReturnCategoryOutput_WhenValid(string label)
  {
    // Arrange
    ParseOk(_typeRefParser);
    ParseModifiersOk();
    TakeReturns('}', true);

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<CategoryOutput>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenTypeRefFails(string label)
  {
    // Arrange
    ParseError(_typeRefParser);

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenModifiersFail(string label)
  {
    // Arrange
    ParseOk(_typeRefParser);
    ParseModifiersError();

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<CategoryOutput>>();
  }
}
