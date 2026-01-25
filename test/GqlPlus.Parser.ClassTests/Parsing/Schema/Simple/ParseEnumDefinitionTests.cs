using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumDefinitionTests
  : SimpleParserClassTestBase
{
  private readonly Parser<IGqlpEnumLabel>.I _enumLabelParser;
  private readonly ParseEnumDefinition _parser;

  public ParseEnumDefinitionTests()
  {
    Parser<IGqlpEnumLabel>.D enumLabelParser = ParserFor(out _enumLabelParser);
    _parser = new ParseEnumDefinition(TypeRef, enumLabelParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string parentType, string label)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_enumLabelParser);
    TakeReturns('}', false, true);

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<EnumDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenParentTypeInvalid(string label)
  {
    // Arrange
    TakeReturns(':', true);
    IdentifierReturns(OutFail);
    SetupError<EnumDefinition>();

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenLabelErrors(string label)
  {
    // Arrange
    TakeReturns(':', false);
    ParseError(_enumLabelParser);
    SetupPartial(new EnumDefinition());

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<EnumDefinition>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenNoLabels(string label)
  {
    // Arrange
    TakeReturns(':', false);
    TakeReturns('}', true);
    SetupPartial(new EnumDefinition());

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<EnumDefinition>>();
  }
}
