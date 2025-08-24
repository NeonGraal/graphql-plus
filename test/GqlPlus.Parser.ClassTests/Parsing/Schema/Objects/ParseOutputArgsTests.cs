using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputArgsTests
  : ObjectArgsParseTestBase<IGqlpOutputArg>
{
  protected override Parser<IGqlpOutputArg>.IA Parser { get; } = new ParseOutputArgs();

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValidEnum(string argType, string argLabel)
  {
    // Arrange
    TakeReturns('<', true);
    IdentifierReturns(OutString(argType), OutString(argLabel), OutFail);
    TakeReturns('.', true);
    TakeReturns('>', true);

    // Act
    IResultArray<IGqlpOutputArg> result = Parser.Parse(Tokenizer, "testLabel");

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
    IResultArray<IGqlpOutputArg> result = Parser.Parse(Tokenizer, "testLabel");

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
    IResultArray<IGqlpOutputArg> result = Parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
