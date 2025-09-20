using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjArgsTest
  : ParserClassTestBase
{
  protected Parser<IGqlpObjArg>.IA Parser { get; } = new ParseObjArgs();

  protected ParseObjArgsTest()
    => PrefixReturns('$', OutPass);

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenZero()
  {
    // Arrange
    TakeReturns('<', true);
    Tokenizer.TakeZero().Returns(true);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjArg>>();
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnOk_WhenChar(char argType)
  {
    // Arrange
    TakeReturns('<', true);
    TakeAnyReturns(OutChar(argType));
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenTwoValid(string argType1, string argType2)
  {
    this.SkipEqual(argType1, argType2);

    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType1), OutString(argType2), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoArgs()
  {
    // Arrange
    TakeReturns('<', false);

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    SetupError<IGqlpObjArg>();

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValidEnum(string argType, string argLabel)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutString(argLabel), OutFail);
    TakeReturns('.', true);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenTypeParamEnum(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    PrefixReturns('$', OutStringAt(argType));
    TakeReturns('.', true);
    SetupError<IGqlpObjArg>();

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

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
    SetupError<IGqlpObjArg>();

    // Act
    IResultArray<IGqlpObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
