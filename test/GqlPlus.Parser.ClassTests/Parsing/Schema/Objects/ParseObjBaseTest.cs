using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjBaseTest
  : ParserClassTestBase
{
  private readonly Parser<IGqlpObjArg>.IA _parseArgs;
  protected Parser<IGqlpObjBase>.I BaseParser { get; }

  protected Parser<IGqlpObjArg>.DA ParseArgs { get; }

  public ParseObjBaseTest()
  {
    ParseArgs = ParserAFor(out _parseArgs);
    BaseParser = new ParseObjBase(ParseArgs);

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParam_WhenValid(string paramName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(paramName));

    // Act
    IResult<IGqlpObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObjBase>>()
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
    SetupError<IGqlpObjBase>();

    // Act
    IResult<IGqlpObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

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
    IResult<IGqlpObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObjBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnBase_WhenZero()
  {
    // Arrange
    Tokenizer.TakeZero().Returns(true);
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IGqlpObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObjBase>>();
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnBase_WhenChar(char baseType)
  {
    // Arrange
    TakeAnyReturns(OutChar(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IGqlpObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpObjBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpObjBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
