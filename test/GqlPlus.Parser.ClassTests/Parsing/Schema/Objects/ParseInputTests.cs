using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputTests
  : DeclarationClassTestBase
{

  private readonly IParserArray<IAstTypeParam> _param;
  private readonly IParser<ObjectDefinition<IAstInputField>> _definition;
  private readonly ObjectParser<IAstInputField> _parser;

  public ParseInputTests()
  {
    ConfigureRepoArray<IAstTypeParam>(Parsers, out _param);
    ConfigureRepo<ObjectDefinition<IAstInputField>>(Parsers, out _definition);
    _parser = new ObjectParser<IAstInputField>(TypeKind.Input, Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputObject_WhenValid(string inputName)
  {
    // Arrange
    NameReturns(inputName);
    ParseOk(_definition, new ObjectDefinition<IAstInputField>());

    // Act
    IResult<IAstObject<IAstInputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObject<IAstInputField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IAstObject<IAstInputField>>();

    // Act
    IResult<IAstObject<IAstInputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
