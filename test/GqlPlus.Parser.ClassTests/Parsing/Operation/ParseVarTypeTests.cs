namespace GqlPlus.Parsing.Operation;

public class ParseVarTypeTests
  : ParserClassTestBase
{

  private readonly ParseVarType _parseVarType;

  public ParseVarTypeTests()
  {
    _parseVarType = new ParseVarType();

    SetupPartial(string.Empty);
    SetupError<string>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableType_WhenIdentifierIsParsed(string identifier)
  {
    // Arrange
    IdentifierReturns(OutString(identifier));

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe(identifier);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableTypeWithExclamationMark_WhenExclamationMarkIsPresent(string identifier)
  {
    // Arrange
    IdentifierReturns(OutString(identifier));
    TakeReturns('!', true);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe(identifier + "!");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnArrayVariableType_WhenBracketsArePresent(string innerType)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutString(innerType));
    TakeReturns(']', true);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe($"[{innerType}]");
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInnerTypeIsMissing()
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutFail);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenClosingBracketIsMissing(string innerType)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutString(innerType));
    TakeReturns(']', false);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<string>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Arrange
    IdentifierReturns(OutFail);
    TakeReturns('[', false);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
