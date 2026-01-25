using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseDeclarationTests
  : ParserClassTestBase
{
  private readonly DeclarationSelector<IGqlpDeclaration> _selector = new("category");
  private readonly Parser<IGqlpDeclaration>.I _declaration;
  private readonly Parser<IGqlpDeclaration>.D _declarationFactory;
  private readonly ParseDeclaration<IGqlpDeclaration> _parser;

  public ParseDeclarationTests()
  {
    _declarationFactory = ParserFor(out _declaration);
    _parser = new ParseDeclaration<IGqlpDeclaration>(_selector, _declarationFactory);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnDeclaration_WhenValid(string label)
  {
    // Arrange
    ParseOk(_declaration);

    // Act
    IResult<IGqlpDeclaration> result = _parser.Parser(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpDeclaration>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalid(string label)
  {
    // Arrange
    ParseError(_declaration);
    SetupError<IGqlpDeclaration>();

    // Act
    IResult<IGqlpDeclaration> result = _parser.Parser(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpDeclaration>>();
  }

  [Theory, RepeatData]
  public void Selector_ShouldReturnCorrectValue(string token)
  {
    // Arrange
    DeclarationSelector<IGqlpDeclaration> selector = new(token);
    ParseDeclaration<IGqlpDeclaration> parser = new(selector, _declarationFactory);

    // Act
    string result = parser.Selector;

    // Assert
    result.ShouldBe(token);
  }
}

