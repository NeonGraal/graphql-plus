using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Globals;

public class ParseDirectiveDefinitionTests : ParserClassTestBase
{
  private readonly IEnumParser<DirectiveLocation> _locationParser;
  private readonly ParseDirectiveDefinition _parser;

  public ParseDirectiveDefinitionTests()
  {
    Parser<IEnumParser<DirectiveLocation>, DirectiveLocation>.D locationParser = EnumParserFor(out _locationParser);
    _parser = new ParseDirectiveDefinition(locationParser);
    SetupPartial(DirectiveLocation.None);
    TakeReturns('}', false, true);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDirectiveLocation_WhenValid(string label)
  {
    // Arrange
    ParseOk(_locationParser, DirectiveLocation.Operation);

    // Act
    IResult<DirectiveLocation> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<DirectiveLocation>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNoLocations(string label)
  {
    // Arrange
    ParseOk(_locationParser, DirectiveLocation.None);

    // Act
    IResult<DirectiveLocation> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DirectiveLocation>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenLocationParsingFails(string label)
  {
    // Arrange
    ParseError(_locationParser);

    // Act
    IResult<DirectiveLocation> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<DirectiveLocation>>();
  }
}
