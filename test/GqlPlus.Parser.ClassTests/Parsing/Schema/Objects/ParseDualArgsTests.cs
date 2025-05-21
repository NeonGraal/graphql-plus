using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualArgsTests
  : ParserClassTestBase
{
  private readonly ParseDualArgs _parser;

  public ParseDualArgsTests()
  {
    _parser = new ParseDualArgs();

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDualArg_WhenValid(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpDualArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpDualArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoArgs()
  {
    // Arrange
    TakeReturns('<', false);

    // Act
    IResultArray<IGqlpDualArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    SetupError<IGqlpDualArg>();

    // Act
    IResultArray<IGqlpDualArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
