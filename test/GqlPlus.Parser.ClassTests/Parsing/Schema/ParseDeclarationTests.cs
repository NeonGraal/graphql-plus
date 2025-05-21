using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseDeclarationTests
  : ParserClassTestBase
{
  private readonly IDeclarationSelector<IGqlpDeclaration> _selector = Substitute.For<IDeclarationSelector<IGqlpDeclaration>>();
  private readonly Parser<IGqlpDeclaration>.I _declaration;
  private readonly ParseDeclaration<IGqlpDeclaration> _parser;

  public ParseDeclarationTests()
  {
    Parser<IGqlpDeclaration>.D declaration = ParserFor(out _declaration);
    _parser = new ParseDeclaration<IGqlpDeclaration>(_selector, declaration);
  }

  [Fact]
  public void Parse_ShouldReturnDeclaration_WhenValid()
  {
    // Arrange
    ParseOk(_declaration);

    // Act
    IResult<IGqlpDeclaration> result = _parser.Parser(Tokenizer, "testLabel");

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
    IResult<IGqlpDeclaration> result = _parser.Parser(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError<IGqlpDeclaration>>();
  }
}

