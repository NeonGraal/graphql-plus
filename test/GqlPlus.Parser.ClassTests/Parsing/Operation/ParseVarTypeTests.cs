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
  public void Parse_ShouldReturnVariableType_WhenIdentifierIsParsed(string identifier, string label)
  {
    // Arrange
    IdentifierReturns(OutString(identifier));

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe(identifier);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableTypeWithExclamationMark_WhenExclamationMarkIsPresent(string identifier, string label)
  {
    // Arrange
    IdentifierReturns(OutString(identifier));
    TakeReturns('!', true);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe(identifier + "!");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnArrayVariableType_WhenBracketsArePresent(string innerType, string label)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutString(innerType));
    TakeReturns(']', true);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe($"[{innerType}]");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInnerTypeIsMissing(string label)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutFail);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenClosingBracketIsMissing(string innerType, string label)
  {
    // Arrange
    TakeReturns('[', true);
    IdentifierReturns(OutString(innerType));
    TakeReturns(']', false);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<string>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed(string label)
  {
    // Arrange
    IdentifierReturns(OutFail);
    TakeReturns('[', false);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
