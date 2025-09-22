using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinitionTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpObjAlt>.IA _alternates;
  private readonly Parser<IGqlpObjField>.I _parseField;
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly ParseObjectDefinition<IGqlpObjField> _parser;

  public ParseObjectDefinitionTests()
  {
    Parser<IGqlpObjAlt>.DA alternates = ParserAFor(out _alternates);
    Parser<IGqlpObjField>.D parseField = ParserFor(out _parseField);
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseObjectDefinition<IGqlpObjField>(alternates, parseField, parseBase);
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
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenJustAlternate()
  {
    // Arrange
    ParseEmpty(_parseField);
    ParseOkA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenJustField()
  {
    // Arrange
    ParseOk(_parseField);
    ParseEmptyA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenManyFields()
  {
    // Arrange
    ParseOk(_parseField, 3);
    ParseEmptyA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParentErrors()
  {
    // Arrange
    TakeReturns(':', true);
    ParseError(_parseBase);
    SetupError<ObjectDefinition<IGqlpObjField>>();

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

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
    SetupPartial(new ObjectDefinition<IGqlpObjField>());

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenAlternatesError()
  {
    // Arrange
    TakeReturns(':', true);
    ParseEmpty(_parseField);
    ParseErrorA(_alternates);
    SetupPartial(new ObjectDefinition<IGqlpObjField>());

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenThirdFieldErrors()
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOkError(_parseField, 2);
    SetupPartial(new ObjectDefinition<IGqlpObjField>());

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjField>>>();
  }
}
