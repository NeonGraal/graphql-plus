using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputFieldTests
  : AliasesClassTestBase
{
  private readonly Parser<IGqlpInputBase>.I _parseBase;
  private readonly IParserDefault _parseDefault;
  private readonly ParseInputField _parser;

  public ParseInputFieldTests()
  {
    Parser<IGqlpInputBase>.D parseBase = ParserFor(out _parseBase);
    Parser<IParserDefault, IGqlpConstant>.D parseDefault = ParserFor<IParserDefault, IGqlpConstant>(out _parseDefault);
    _parser = new ParseInputField(Aliases, Modifiers, parseBase, parseDefault);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputField_WhenValid(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);

    // Act
    IResult<IGqlpInputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpInputField>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoFieldName()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpInputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
