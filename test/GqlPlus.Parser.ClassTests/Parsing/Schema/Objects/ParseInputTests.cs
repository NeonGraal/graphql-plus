using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputTests
  : DeclarationClassTestBase
{
  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpInputField>>.I _definition;
  private readonly ParseInput _parser;

  public ParseInputTests()
  {
    Parser<IGqlpTypeParam>.DA param = ParserAFor(out _param);
    Parser<ObjectDefinition<IGqlpInputField>>.D definition = ParserFor(out _definition);
    _parser = new ParseInput(SimpleName, param, Aliases, OptionNull, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputObject_WhenValid(string inputName)
  {
    // Arrange
    NameReturns(inputName);
    ParseOk(_definition, new ObjectDefinition<IGqlpInputField>());

    // Act
    IResult<IGqlpInputObject> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpInputObject>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpInputObject>();

    // Act
    IResult<IGqlpInputObject> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
