using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputTests
  : DeclarationClassTestBase
{
  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpOutputField>>.I _definition;
  private readonly ParseOutput _parser;

  public ParseOutputTests()
  {
    Parser<IGqlpTypeParam>.DA param = ParserAFor(out _param);
    Parser<ObjectDefinition<IGqlpOutputField>>.D definition = ParserFor(out _definition);
    _parser = new ParseOutput(SimpleName, param, Aliases, OptionNull, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputObject_WhenValid(string outputName)
  {
    // Arrange
    NameReturns(outputName);
    ParseOk(_definition, new ObjectDefinition<IGqlpOutputField>());

    // Act
    IResult<IGqlpOutputObject> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputObject>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpOutputObject>();

    // Act
    IResult<IGqlpOutputObject> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
