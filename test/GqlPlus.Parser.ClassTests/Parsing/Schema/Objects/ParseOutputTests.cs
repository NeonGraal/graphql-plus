using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputTests
  : DeclarationClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpOutputField>>.I _definition;
  private readonly ObjectParser<IGqlpOutputField> _parser;

  public ParseOutputTests()
  {
    Parser<IGqlpTypeParam>.DA param = ParserAFor(out _param);
    Parser<ObjectDefinition<IGqlpOutputField>>.D definition = ParserFor(out _definition);
    IGqlpFieldKind<IGqlpOutputField> fieldKind = new FieldObjectKind<IGqlpOutputField>(TypeKind.Output);
    _parser = new ObjectParser<IGqlpOutputField>(SimpleName, param, Aliases, OptionNull, definition, fieldKind);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputObject_WhenValid(string outputName)
  {
    // Arrange
    NameReturns(outputName);
    ParseOk(_definition, new ObjectDefinition<IGqlpOutputField>());

    // Act
    IResult<IGqlpObject<IGqlpOutputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObject<IGqlpOutputField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpObject<IGqlpOutputField>>();

    // Act
    IResult<IGqlpObject<IGqlpOutputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
