using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseDeclarationTests
  : ParserClassTestBase
{

  private readonly string _selector = "category";
  private readonly Parser<IGqlpDeclaration>.I _declaration;
  private readonly ParseDeclaration<IGqlpDeclaration> _parser;
  private readonly IParserRepository _parsers;

  public ParseDeclarationTests()
  {
    _parsers = A.Of<IParserRepository>();
    ConfigureRepo<IGqlpDeclaration>(_parsers, out _declaration);
    _parser = new ParseDeclaration<IGqlpDeclaration>(_selector, _parsers);
  }

  [Fact]
  public void Parse_ShouldReturnDeclaration_WhenValid()
  {
    // Arrange
    ParseOk(_declaration);

    // Act
    IResult<IGqlpDeclaration> result = _parser.Parser(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDeclaration>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    ParseError(_declaration);
    SetupError<IGqlpDeclaration>();

    // Act
    IResult<IGqlpDeclaration> result = _parser.Parser(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpDeclaration>>();
  }

  [Theory, RepeatData]
  public void Selector_ShouldReturnCorrectValue(string token)
  {
    // Arrange
    ParseDeclaration<IGqlpDeclaration> parser = new(token, _parsers);

    // Act
    string result = parser.Selector;

    // Assert
    result.ShouldBe(token);
  }
}
