using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputTests
  : DeclarationClassTestBase
{

  private readonly Parser<IAstTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IAstOutputField>>.I _definition;
  private readonly ObjectParser<IAstOutputField> _parser;

  public ParseOutputTests()
  {
    ConfigureRepoArray<IAstTypeParam>(Parsers, out _param);
    ConfigureRepo<ObjectDefinition<IAstOutputField>>(Parsers, out _definition);
    _parser = new ObjectParser<IAstOutputField>(TypeKind.Output, Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputObject_WhenValid(string outputName)
  {
    // Arrange
    NameReturns(outputName);
    ParseOk(_definition, new ObjectDefinition<IAstOutputField>());

    // Act
    IResult<IAstObject<IAstOutputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObject<IAstOutputField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IAstObject<IAstOutputField>>();

    // Act
    IResult<IAstObject<IAstOutputField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
