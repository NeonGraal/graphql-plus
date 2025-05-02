namespace GqlPlus.Parsing.Operation;

public class ParseVarTypeTests
  : ParserClassTestBase
{
  private readonly ParseVarType _parseVarType;

  public ParseVarTypeTests()
    => _parseVarType = new ParseVarType();

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableType_WhenIdentifierIsParsed(string identifier)
  {
    // Arrange
    Tokenizer.Identifier(out string? _).Returns(OutString(identifier));

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe(identifier);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnVariableTypeWithExclamationMark_WhenExclamationMarkIsPresent(string identifier)
  {
    // Arrange
    Tokenizer.Identifier(out string? _).Returns(OutString(identifier));
    Tokenizer.Take('!').Returns(true, false);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe(identifier + "!");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnArrayVariableType_WhenBracketsArePresent(string innerType)
  {
    // Arrange
    Tokenizer.Take('[').Returns(true, false);
    Tokenizer.Identifier(out string? _).Returns(OutString(innerType));
    Tokenizer.Take(']').Returns(true);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<string>>()
      .Required().ShouldBe($"[{innerType}]");
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenClosingBracketIsMissing(string innerType)
  {
    // Arrange
    Tokenizer.Take('[').Returns(true, false);
    Tokenizer.Identifier(out string? _).Returns(OutString(innerType));
    Tokenizer.Take(']').Returns(false);

    SetupPartial("Expected closing bracket ']' for array type.", "");

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<string>>();
  }

  [Fact]
  public void Parse_ShouldReturnEmptyResult_WhenNoValidTokenIsParsed()
  {
    // Arrange
    Tokenizer.Identifier(out string? _).Returns(false);
    Tokenizer.Take('[').Returns(false);

    // Act
    IResult<string> result = _parseVarType.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty<string>>();
  }
}
