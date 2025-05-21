using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputBaseTests
  : ParserClassTestBase
{
  private readonly Parser<IGqlpOutputArg>.IA _parseArgs;
  private readonly ParseOutputBase _parser;

  public ParseOutputBaseTests()
  {
    Parser<IGqlpOutputArg>.DA parseArgs = ParserAFor(out _parseArgs);
    _parser = new ParseOutputBase(parseArgs);

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputBase_WhenValid(string baseType)
  {
    // Arrange
    IdentifierReturns(OutString(baseType));
    ParseEmptyA(_parseArgs);

    // Act
    IResult<IGqlpOutputBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpOutputBase>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<IGqlpOutputBase> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
