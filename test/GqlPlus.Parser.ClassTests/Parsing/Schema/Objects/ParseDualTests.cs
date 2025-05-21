using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests
  : DeclarationClassTestBase
{
  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>>.I _definition;
  private readonly ParseDual _parser;

  public ParseDualTests()
  {
    Parser<IGqlpTypeParam>.DA param = ParserAFor(out _param);
    Parser<ObjectDefinition<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>>.D definition = ParserFor(out _definition);
    _parser = new ParseDual(SimpleName, param, Aliases, OptionNull, definition);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualObject_WhenValid(string dualName)
  {
    // Arrange
    NameReturns(dualName);
    ParseOk(_definition, new ObjectDefinition<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>());

    // Act
    IResult<IGqlpDualObject> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDualObject>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpDualObject>();

    // Act
    IResult<IGqlpDualObject> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
