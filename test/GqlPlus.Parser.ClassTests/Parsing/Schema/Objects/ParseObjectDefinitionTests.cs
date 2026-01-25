using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinitionTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpAlternate>.IA _alternates;
  private readonly Parser<IGqlpObjField>.I _parseField;
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly ParseObjectDefinition<IGqlpObjField> _parser;

  public ParseObjectDefinitionTests()
  {
    Parser<IGqlpAlternate>.DA alternates = ParserAFor(out _alternates);
    Parser<IGqlpObjField>.D parseField = ParserFor(out _parseField);
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseObjectDefinition<IGqlpObjField>(alternates, parseField, parseBase);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenAll(string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOk(_parseField);
    ParseOkA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenJustAlternate(string label)
  {
    // Arrange
    ParseEmpty(_parseField);
    ParseOkA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenJustField(string label)
  {
    // Arrange
    ParseOk(_parseField);
    ParseEmptyA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenManyFields(string label)
  {
    // Arrange
    ParseOk(_parseField, 3);
    ParseEmptyA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParentErrors(string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseError(_parseBase);
    SetupError<ObjectDefinition<IGqlpObjField>>();

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenFieldErrors(string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseError(_parseField);
    SetupPartial(new ObjectDefinition<IGqlpObjField>());

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenAlternatesError(string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseEmpty(_parseField);
    ParseErrorA(_alternates);
    SetupPartial(new ObjectDefinition<IGqlpObjField>());

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjField>>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenThirdFieldErrors(string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOkError(_parseField, 2);
    SetupPartial(new ObjectDefinition<IGqlpObjField>());

    // Act
    IResult<ObjectDefinition<IGqlpObjField>> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjField>>>();
  }
}
