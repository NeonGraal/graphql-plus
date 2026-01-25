using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests
  : DeclarationClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly Parser<IGqlpTypeParam>.IA _param;
  private readonly Parser<ObjectDefinition<IGqlpDualField>>.I _definition;
  private readonly ObjectParser<IGqlpDualField> _parser;

  public ParseDualTests()
  {
    Parser<IGqlpTypeParam>.DA param = ParserAFor(out _param);
    Parser<ObjectDefinition<IGqlpDualField>>.D definition = ParserFor(out _definition);
    IGqlpFieldKind<IGqlpDualField> fieldKind = new FieldObjectKind<IGqlpDualField>(TypeKind.Dual);
    _parser = new ObjectParser<IGqlpDualField>(SimpleName, param, Aliases, OptionNull, definition, fieldKind);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualObject_WhenValid(string dualName)
  {
    // Arrange
    NameReturns(dualName);
    ParseOk(_definition, new ObjectDefinition<IGqlpDualField>());

    // Act
    IResult<IGqlpObject<IGqlpDualField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObject<IGqlpDualField>>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<IGqlpObject<IGqlpDualField>>();

    // Act
    IResult<IGqlpObject<IGqlpDualField>> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
