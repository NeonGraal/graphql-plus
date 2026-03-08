using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseDirectiveDefinitionTests : ParserClassTestBase
{

  private readonly IEnumParser<DirectiveLocation> _locationParser;
  private readonly ParseDirectiveDefinition _parser;

  public ParseDirectiveDefinitionTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoInterface<IEnumParser<DirectiveLocation>, DirectiveLocation>(parsers, out _locationParser);
    _parser = new ParseDirectiveDefinition(parsers);
    SetupPartial(DirectiveLocation.None);
    TakeReturns('}', false, true);
  }

  [Fact]
  public void Parse_ShouldReturnDirectiveLocation_WhenValid()
  {
    // Arrange
    ParseOk(_locationParser, DirectiveLocation.Operation);

    // Act
    IResult<DirectiveLocation> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DirectiveLocation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNoLocations()
  {
    // Arrange
    ParseOk(_locationParser, DirectiveLocation.None);

    // Act
    IResult<DirectiveLocation> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DirectiveLocation>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenLocationParsingFails()
  {
    // Arrange
    ParseError(_locationParser);

    // Act
    IResult<DirectiveLocation> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DirectiveLocation>>();
  }
}
