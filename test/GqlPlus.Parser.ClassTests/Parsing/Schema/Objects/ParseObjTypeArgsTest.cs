using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseObjTypeArgsTest
  : ParserClassTestBase
{
  protected Parser<IGqlpObjTypeArg>.IA Parser { get; } = new ParseObjTypeArgs();

  public ParseObjTypeArgsTest()
    => PrefixReturns('$', OutPass);

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenTypeParam(string typeParam)
  {
    // Arrange
    TakeReturns('<', true);
    PrefixReturns('$', OutStringAt(typeParam));
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenZero()
  {
    // Arrange
    TakeReturns('<', true);
    Tokenizer.TakeZero().Returns(true);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>();
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnOk_WhenChar(char argType)
  {
    // Arrange
    TakeReturns('<', true);
    TakeAnyReturns(OutChar(argType));
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenTwoValid(string argType1, string argType2)
  {
    this.SkipEqual(argType1, argType2);

    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType1), OutString(argType2), OutFail);
    PrefixReturns('$', OutPass, OutPass);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>()
      .Required().Count().ShouldBe(2);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenMixed(string argType, string typeParam)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType));
    PrefixReturns('$', OutStringAt(typeParam), OutPass, OutPass, OutPass);
    Tokenizer.TakeZero().Returns(true);
    TakeAnyReturns(OutChar('_'));
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>()
      .Required().Count().ShouldBe(4);
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoArgs()
  {
    // Arrange
    TakeReturns('<', false);

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    SetupError<IGqlpObjTypeArg>();

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

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
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<IGqlpObjTypeArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenTypeParamEnum(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    PrefixReturns('$', OutStringAt(argType));
    TakeReturns('.', true);
    SetupError<IGqlpObjTypeArg>();

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

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
    SetupError<IGqlpObjTypeArg>();

    // Act
    IResultArray<IGqlpObjTypeArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
