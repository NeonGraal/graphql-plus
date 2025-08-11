using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputArgsTests
  : ParserClassTestBase
{
  private readonly ParseOutputArgs _parser;

  public ParseOutputArgsTests()
  {
    _parser = new ParseOutputArgs();

    PrefixReturns('$', OutPass);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputArg_WhenValid(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpOutputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpOutputArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOutputArg_WhenValidEnum(string argType, string argLabel)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutString(argLabel), OutFail);
    TakeReturns('.', true);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpOutputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpOutputArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenTypeParamEnum(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    PrefixReturns('$', OutStringAt(argType));
    TakeReturns('.', true);
    SetupError<IGqlpOutputArg>();

    // Act
    IResultArray<IGqlpOutputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenErrorEnum(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType));
    TakeReturns('.', true);
    SetupError<IGqlpOutputArg>();

    // Act
    IResultArray<IGqlpOutputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoArgs()
  {
    // Arrange
    TakeReturns('<', false);

    // Act
    IResultArray<IGqlpOutputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    SetupError<IGqlpOutputArg>();

    // Act
    IResultArray<IGqlpOutputArg> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
