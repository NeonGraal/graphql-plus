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
  public void Parse_ShouldReturnInputField_WhenValidDefault(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseOk(_parseDefault);

    // Act
    IResult<IGqlpInputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpInputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputField_WhenNoDefault(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseEmpty(_parseDefault);

    // Act
    IResult<IGqlpInputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpInputField>>()
      .Required().DefaultValue.ShouldBeNull();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenDefaultErrors(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseOk(_parseBase);
    ParseError(_parseDefault);
    SetupPartial<IGqlpInputField>();

    // Act
    IResult<IGqlpInputField> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpInputField>>();
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
