using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;
using NSubstitute;
using Shouldly;
using Xunit;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseCategoryDefinitionTests : ParserClassTestBase
{
  private readonly Parser<IGqlpTypeRef>.I _typeRefParser;
  private readonly Parser<IGqlpModifier>.IA _modifiersParser;
  private readonly ParseCategoryDefinition _parser;

  public ParseCategoryDefinitionTests()
  {
    Parser<IGqlpTypeRef>.D typeRefParser = ParserFor(out _typeRefParser);
    Parser<IGqlpModifier>.DA modifiersParser = ParserAFor(out _modifiersParser);

    _parser = new ParseCategoryDefinition(typeRefParser, modifiersParser);

    SetupError<CategoryOutput>();
    SetupPartial<CategoryOutput>(new(default!));
  }

  [Fact]
  public void Parse_ShouldReturnCategoryOutput_WhenValid()
  {
    // Arrange
    ParseOk(_typeRefParser);
    ParseOkA(_modifiersParser);
    TakeReturns('}', true, false);

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
    result.ShouldBeAssignableTo<IResultError<CategoryOutput>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenModifiersFail()
  {
    // Arrange
    ParseOk(_typeRefParser);
    ParseErrorA(_modifiersParser);

    // Act
    IResult<CategoryOutput> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<CategoryOutput>>();
  }
}
