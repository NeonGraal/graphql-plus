using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputArgsTests
  : ParserClassTestBase
{
  private readonly ParseInputArgs _parser;

  public ParseInputArgsTests()
  {
    _parser = new ParseInputArgs();

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnInputArg_WhenValid(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpInputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpInputArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoArgs()
  {
    // Arrange
    TakeReturns('<', false);

    // Act
    IResultArray<IGqlpInputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    SetupError<IGqlpInputArg>();

    // Act
    IResultArray<IGqlpInputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
