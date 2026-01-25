using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputTests
  : DeclarationClassTestBase
{

  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpInputField>>.I _definition;
  private readonly ObjectParser<IGqlpInputField> _parser;

  public ParseInputTests()
  {
    Parser<IGqlpTypeParam>.DA param = ParserAFor(out _param);
    Parser<ObjectDefinition<IGqlpInputField>>.D definition = ParserFor(out _definition);
    IGqlpFieldKind<IGqlpInputField> fieldKind = new FieldObjectKind<IGqlpInputField>(TypeKind.Input);
    _parser = new ObjectParser<IGqlpInputField>(SimpleName, param, Aliases, OptionNull, definition, fieldKind);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputObject_WhenValid(string inputName)
  {
    // Arrange
    NameReturns(inputName);
    ParseOk(_definition, new ObjectDefinition<IGqlpInputField>());

    // Act
    IResult<IGqlpObject<IGqlpInputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObject<IGqlpInputField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpObject<IGqlpInputField>>();

    // Act
    IResult<IGqlpObject<IGqlpInputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
