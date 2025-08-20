using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class ObjectArgsParseTestBase<TObjArg>
  : ParserClassTestBase
  where TObjArg : IGqlpObjArg
{
  protected abstract Parser<TObjArg>.IA Parser { get; }

  protected ObjectArgsParseTestBase()
    => PrefixReturns('$', OutPass);

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string argType)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<TObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<TObjArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenZero()
  {
    // Arrange
    TakeReturns('<', true);
    Tokenizer.TakeZero().Returns(true);
    TakeReturns('>', true);

    // Act
    IResultArray<TObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<TObjArg>>();
  }

  [Theory, InlineData('^'), InlineData('_'), InlineData('*')]
  public void Parse_ShouldReturnOk_WhenChar(char argType)
  {
    // Arrange
    TakeReturns('<', true);
    TakeAnyReturns(OutChar(argType));
    TakeReturns('>', true);

    // Act
    IResultArray<TObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<TObjArg>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenTwoValid(string argType1, string argType2)
  {
    this.SkipIf(argType1 == argType2);

    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType1), OutString(argType2), OutFail);
    TakeReturns('>', true);

    // Act
    IResultArray<TObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayOk<TObjArg>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoArgs()
  {
    // Arrange
    TakeReturns('<', false);

    // Act
    IResultArray<TObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutFail);
    SetupError<TObjArg>();

    // Act
    IResultArray<TObjArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
