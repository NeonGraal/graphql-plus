using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseDeclarationTests
  : ParserClassTestBase
{

  private readonly string _selector = "category";
  private readonly Parser<IAstDeclaration>.I _declaration;
  private readonly ParseDeclaration<IAstDeclaration> _parser;
  private readonly IParserRepository _parsers;

  public ParseDeclarationTests()
  {
    _parsers = A.Of<IParserRepository>();
    ConfigureRepo<IAstDeclaration>(_parsers, out _declaration);
    _parser = new ParseDeclaration<IAstDeclaration>(_selector, _parsers);
  }

  [Fact]
  public void Parse_ShouldReturnDeclaration_WhenValid()
  {
    // Arrange
    ParseOk(_declaration);

    // Act
    IResult<IAstDeclaration> result = _parser.Parser(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstDeclaration>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    ParseError(_declaration);
    SetupError<IAstDeclaration>();

    // Act
    IResult<IAstDeclaration> result = _parser.Parser(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError<IAstDeclaration>>();
  }

  [Theory, RepeatData]
  public void Selector_ShouldReturnCorrectValue(string token)
  {
    // Arrange
    ParseDeclaration<IAstDeclaration> parser = new(token, _parsers);

    // Act
    string result = parser.Selector;

    // Assert
    result.ShouldBe(token);
  }
}
