using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputTests
  : DeclarationClassTestBase
{
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
  public void Parse_ShouldReturnOutputObject_WhenValid(string outputName, string label)
  {
    // Arrange
    NameReturns(outputName);
    ParseOk(_definition, new ObjectDefinition<IGqlpOutputField>());

    // Act
    IResult<IGqlpObject<IGqlpOutputField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObject<IGqlpOutputField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalid(string label)
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpObject<IGqlpOutputField>>();

    // Act
    IResult<IGqlpObject<IGqlpOutputField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
