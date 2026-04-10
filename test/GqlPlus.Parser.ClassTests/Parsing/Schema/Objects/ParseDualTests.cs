using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests
  : DeclarationClassTestBase
{

  private readonly Parser<IAstTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IAstDualField>>.I _definition;
  private readonly ObjectParser<IAstDualField> _parser;

  public ParseDualTests()
  {
    ConfigureRepoArray<IAstTypeParam>(Parsers, out _param);
    ConfigureRepo<ObjectDefinition<IAstDualField>>(Parsers, out _definition);
    _parser = new ObjectParser<IAstDualField>(TypeKind.Dual, Parsers);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualObject_WhenValid(string dualName)
  {
    // Arrange
    NameReturns(dualName);
    ParseOk(_definition, new ObjectDefinition<IAstDualField>());

    // Act
    IResult<IAstObject<IAstDualField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObject<IAstDualField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IAstObject<IAstDualField>>();

    // Act
    IResult<IAstObject<IAstDualField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
