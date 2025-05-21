using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputBaseTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpInputArg>.IA _parseArgs;
  private readonly ParseInputBase _parser;

  public ParseInputBaseTests()
  {
    Parser<IGqlpInputArg>.DA parseArgs = ParserAFor(out _parseArgs);
    _parser = new ParseInputBase(parseArgs);

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputBase_WhenValid(string baseType)
  {
    // Arrange
    IdentifierReturns(OutString(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IGqlpInputBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpInputBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpInputBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
