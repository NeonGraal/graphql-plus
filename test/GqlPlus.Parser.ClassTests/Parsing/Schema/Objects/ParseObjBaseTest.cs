using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjBaseTest
  : ParserClassTestBase
{
  private readonly Parser<IAstTypeArg>.IA _parseArgs;
  protected Parser<IAstObjBase>.I BaseParser { get; }

  public ParseObjBaseTest()
  {
    IParserRepository parsers = A.Of<IParserRepository>();
    ConfigureRepoArray<IAstTypeArg>(parsers, out _parseArgs);
    BaseParser = new ParseObjBase(parsers);
    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParam_WhenValid(string paramName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(paramName));

    // Act
    IResult<IAstObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObjBase>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.IsTypeParam.ShouldBeTrue(),
        r => r.Name.ShouldBe(paramName)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParamErrors()
  {
    // Arrange
    PrefixReturns('$', OutFail);
    SetupError<IAstObjBase>();

    // Act
    IResult<IAstObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnBase_WhenValid(string baseType)
  {
    // Arrange
    IdentifierReturns(OutString(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IAstObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObjBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnBase_WhenZero()
  {
    // Arrange
    Tokenizer.TakeZero().Returns(true);
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IAstObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObjBase>>();
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnBase_WhenChar(char baseType)
  {
    // Arrange
    TakeAnyReturns(OutChar(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IAstObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstObjBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IAstObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
