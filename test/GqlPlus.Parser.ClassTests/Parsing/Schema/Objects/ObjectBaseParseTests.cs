using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class ObjectBaseParseTests<TBase, TArg>
  : ParserClassTestBase
  where TBase : IGqlpObjBase
  where TArg : IGqlpObjArg
{
  private readonly Parser<TArg>.IA _parseArgs;
  protected abstract Parser<TBase>.I BaseParser { get; }

  protected Parser<TArg>.DA ParseArgs { get; }

  protected ObjectBaseParseTests()
  {
    ParseArgs = ParserAFor(out _parseArgs);

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnParam_WhenValid(string paramName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(paramName));

    // Act
    IResult<TBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TBase>>()
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
    SetupError<TBase>();

    // Act
    IResult<TBase> result = BaseParser.Parse(Tokenizer, "testLabel");

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
    IResult<TBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnBase_WhenZero()
  {
    // Arrange
    Tokenizer.TakeZero().Returns(true);
    ParseEmptyA(_parseArgs);

    // Act
    IResult<TBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TBase>>();
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnBase_WhenChar(char baseType)
  {
    // Arrange
    TakeAnyReturns(OutChar(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<TBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<TBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<TBase> result = BaseParser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
