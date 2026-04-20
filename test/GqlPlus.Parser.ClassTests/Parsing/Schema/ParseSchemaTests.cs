using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseSchemaTests
  : ParserClassTestBase
{

  private readonly IParseDeclaration _declarationParser = A.Of<IParseDeclaration>();
  private readonly IParserRepository _repo = A.Of<IParserRepository>();
  private readonly ParseSchema _parser;

  public ParseSchemaTests()
  {
    _declarationParser.Selector.Returns("category");
    _repo.GetDeclarations().Returns([_declarationParser]);

    _parser = new ParseSchema(_repo);

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
    IResult<IAstSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Success);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenUnknownSelector()
  {
    // Arrange
    IdentifierReturns(OutString("unknown"));
    Tokenizer.AtEnd.Returns(true);

    SetupError<IAstSchema>();

    // Act
    IResult<IAstSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Failure);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenToMuchText()
  {
    // Arrange
    IdentifierReturns(OutString("category"));

    SetupError<IAstSchema>();

    // Act
    IResult<IAstSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Failure);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenNoText()
  {
    // Arrange
    Tokenizer.Read().Returns(false);

    SetupError<IAstSchema>();

    // Act
    IResult<IAstSchema> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
