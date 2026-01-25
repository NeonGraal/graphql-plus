using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseSchemaTests
  : ParserClassTestBase
{

  private readonly IParseDeclaration _declarationParser = A.Of<IParseDeclaration>();
  private readonly ParseSchema _parser;

  public ParseSchemaTests()
  {
    _declarationParser.Selector.Returns("category");

    _parser = new([_declarationParser]);

    Tokenizer.AtStart.Returns(true);
    Tokenizer.Read().Returns(true);
  }

  [Fact]
  public void Parse_ShouldReturnSchema_WhenValid()
  {
    // Arrange
    IdentifierReturns(OutString("category"));
    Tokenizer.AtEnd.Returns(true);

    // Act
    IResult<IGqlpSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Success);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenUnknownSelector()
  {
    // Arrange
    IdentifierReturns(OutString("unknown"));
    Tokenizer.AtEnd.Returns(true);

    SetupError<IGqlpSchema>();

    // Act
    IResult<IGqlpSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Failure);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenToMuchText()
  {
    // Arrange
    IdentifierReturns(OutString("category"));

    SetupError<IGqlpSchema>();

    // Act
    IResult<IGqlpSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Failure);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoText()
  {
    // Arrange
    Tokenizer.Read().Returns(false);

    SetupError<IGqlpSchema>();

    // Act
    IResult<IGqlpSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
