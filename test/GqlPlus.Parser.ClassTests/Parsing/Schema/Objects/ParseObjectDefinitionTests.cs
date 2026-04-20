using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinitionTests
  : ParserClassTestBase
{

  private readonly Parser<IAstAlternate>.IA _alternates;
  private readonly Parser<IAstObjField>.I _parseField;
  private readonly Parser<IAstObjBase>.I _parseBase;
  private readonly ParseObjectDefinition<IAstObjField> _parser;

  public ParseObjectDefinitionTests()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoArray<IAstAlternate>(parsers, out _alternates);
    ConfigureRepo<IAstObjField>(parsers, out _parseField);
    ConfigureRepo<IAstObjBase>(parsers, out _parseBase);
    _parser = new ParseObjectDefinition<IAstObjField>(parsers);
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenAll()
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOk(_parseField);
    ParseOkA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IAstObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenJustAlternate()
  {
    // Arrange
    ParseEmpty(_parseField);
    ParseOkA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IAstObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenJustField()
  {
    // Arrange
    ParseOk(_parseField);
    ParseEmptyA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IAstObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenManyFields()
  {
    // Arrange
    ParseOk(_parseField, 3);
    ParseEmptyA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IAstObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParentErrors()
  {
    // Arrange
    TakeReturns(':', true);
    ParseError(_parseBase);
    SetupError<ObjectDefinition<IAstObjField>>();

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenFieldErrors()
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseError(_parseField);
    SetupPartial(new ObjectDefinition<IAstObjField>());

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IAstObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenAlternatesError()
  {
    // Arrange
    TakeReturns(':', true);
    ParseEmpty(_parseField);
    ParseErrorA(_alternates);
    SetupPartial(new ObjectDefinition<IAstObjField>());

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IAstObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenThirdFieldErrors()
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOkError(_parseField, 2);
    SetupPartial(new ObjectDefinition<IAstObjField>());

    // Act
    IResult<ObjectDefinition<IAstObjField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IAstObjField>>>();
  }
}
