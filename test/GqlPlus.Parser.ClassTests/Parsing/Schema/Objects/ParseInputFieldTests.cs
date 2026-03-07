using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputFieldTests
  : ObjectFieldParseTestBase<IGqlpInputField>
{
  private readonly IParserDefault _parseDefault;

  protected override Parser<IGqlpInputField>.I Parser { get; }

  public ParseInputFieldTests()
  {
    ConfigureRepoInterface<IParserDefault, IGqlpConstant>(Parsers, out _parseDefault);
    Parser = new ParseInputField(Parsers);
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
