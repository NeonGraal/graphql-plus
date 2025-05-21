using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumDefinitionTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpEnumLabel>.I _enumLabelParser;
  private readonly ParseEnumDefinition _parser;

  public ParseEnumDefinitionTests()
  {
    Parser<IGqlpEnumLabel>.D enumLabelParser = ParserFor(out _enumLabelParser);
    _parser = new ParseEnumDefinition(enumLabelParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumDefinition_WhenValid(string parentType)
  {
    // Arrange
    TakeReturns(':', true);
    IdentifierReturns(OutString(parentType));
    ParseOk(_enumLabelParser);
    TakeReturns('}', false, true);

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<EnumDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParentTypeInvalid()
  {
    // Arrange
    TakeReturns(':', true);
    IdentifierReturns(OutFail);
    SetupError<EnumDefinition>();

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenNoLabels()
  {
    // Arrange
    TakeReturns(':', false);
    ParseError(_enumLabelParser);
    SetupPartial(new EnumDefinition());

    // Act
    IResult<EnumDefinition> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<EnumDefinition>>();
  }
}
