using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualBaseTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpDualArg>.IA _parseArgs;
  private readonly ParseDualBase _parser;

  public ParseDualBaseTests()
  {
    Parser<IGqlpDualArg>.DA parseArgs = ParserAFor(out _parseArgs);
    _parser = new ParseDualBase(parseArgs);

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualParam_WhenValid(string paramName)
  {
    // Arrange
    PrefixReturns('$', OutStringAt(paramName));

    // Act
    IResult<IGqlpDualBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDualBase>>()
      .Required().ShouldSatisfyAllConditions(
        r => r.IsTypeParam.ShouldBeTrue(),
        r => r.Dual.ShouldBe(paramName)
      );
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParamErrors()
  {
    // Arrange
    PrefixReturns('$', OutFail);
    SetupError<DualBaseAst>();

    // Act
    IResult<IGqlpDualBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualBase_WhenValid(string baseType)
  {
    // Arrange
    IdentifierReturns(OutString(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IGqlpDualBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDualBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpDualBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
