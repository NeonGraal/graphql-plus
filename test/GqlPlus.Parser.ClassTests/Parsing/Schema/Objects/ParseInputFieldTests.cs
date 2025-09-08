using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputFieldTests
  : ObjectFieldParseTestBase<IGqlpInputField, IGqlpInputBase>
{
  private readonly IParserDefault _parseDefault;

  protected override Parser<IGqlpInputField>.I Parser { get; }

  public ParseInputFieldTests()
  {
    Parser<IParserDefault, IGqlpConstant>.D parseDefault = ParserFor<IParserDefault, IGqlpConstant>(out _parseDefault);
    Parser = new ParseInputField(Aliases, Modifiers, ParseBase, parseDefault);

    ParseEmpty(_parseDefault);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputField_WhenValidDefault(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseBaseOk();
    ParseOk(_parseDefault);

    // Act
    IResult<IGqlpInputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpInputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenDefaultErrors(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseBaseOk();
    ParseError(_parseDefault);
    SetupPartial<IGqlpInputField>();

    // Act
    IResult<IGqlpInputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpInputField>>();
  }
}
