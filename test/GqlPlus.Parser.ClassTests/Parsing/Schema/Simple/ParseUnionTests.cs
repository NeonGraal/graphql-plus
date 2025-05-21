using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseUnionTests
  : DeclarationClassTestBase
{
  private readonly Parser<UnionDefinition>.I _definition;
  private readonly ParseUnion _parser;

  public ParseUnionTests()
  {
    Parser<UnionDefinition>.D definition = ParserFor(out _definition);
    _parser = new ParseUnion(SimpleName, ParamNull, Aliases, OptionNull, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnUnion_WhenValid(string unionName)
  {
    // Arrange
    NameReturns(unionName);
    ParseOk(_definition, new UnionDefinition());

    // Act
    IResult<IGqlpUnion> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpUnion>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    NameFails();
    SetupError<IGqlpUnion>();

    // Act
    IResult<IGqlpUnion> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
