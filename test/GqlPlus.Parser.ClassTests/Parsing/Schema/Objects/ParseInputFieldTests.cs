using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputFieldTests
  : ObjectFieldParseTestBase<IAstInputField>
{
  private readonly IParserDefault _parseDefault;

  protected override Parser<IAstInputField>.I Parser { get; }

  public ParseInputFieldTests()
  {
    ConfigureRepoInterface<IParserDefault, IAstConstant>(Parsers, out _parseDefault);
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
    IResult<IAstInputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstInputField>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenDefaultErrors(string fieldName)
  {
    // Arrange
    IdentifierReturns(OutString(fieldName));
    TakeReturns(':', true);
    ParseBaseOk();
    ParseError(_parseDefault);
    SetupPartial<IAstInputField>();

    // Act
    IResult<IAstInputField> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstInputField>>();
  }
}
