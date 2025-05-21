using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjectDefinitionTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpObjAlternate>.IA _alternates;
  private readonly Parser<IGqlpObjField>.I _parseField;
  private readonly Parser<IGqlpObjBase>.I _parseBase;
  private readonly ParseObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate> _parser;

  public ParseObjectDefinitionTests()
  {
    Parser<IGqlpObjAlternate>.DA alternates = ParserAFor(out _alternates);
    Parser<IGqlpObjField>.D parseField = ParserFor(out _parseField);
    Parser<IGqlpObjBase>.D parseBase = ParserFor(out _parseBase);
    _parser = new ParseObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate>(alternates, parseField, parseBase);
  }

  [Fact]
  public void Parse_ShouldReturnObjectDefinition_WhenValid()
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOk(_parseField);
    ParseOkA(_alternates);
    TakeReturns('}', true);

    // Act
    IResult<ObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<ObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate>>>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNoFields()
  {
    // Arrange
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseError(_parseField);
    SetupPartial(new ObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate>());

    // Act
    IResult<ObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate>> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<ObjectDefinition<IGqlpObjBase, IGqlpObjField, IGqlpObjAlternate>>>();
  }
}
