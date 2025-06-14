using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseSchemaTests
  : ParserClassTestBase
{
  private readonly IParseDeclaration _declarationParser = A.Of<IParseDeclaration>();
  private readonly ParseSchema _parser;

  public ParseSchemaTests()
    => _parser = new([_declarationParser]);

  [Fact]
  public void Parse_ShouldReturnSchema_WhenValid()
  {
    // Arrange
    IdentifierReturns(OutString("category"), OutFail);
    Tokenizer.AtEnd.Returns(true);

    _declarationParser.Selector.Returns("category");

    // Act
    IResult<IGqlpSchema> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Success);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenUnknownSelector()
  {
    // Arrange
    IdentifierReturns(OutString("unknown"), OutFail);
    Tokenizer.AtEnd.Returns(true);

    _declarationParser.Selector.Returns("category");
    SetupError<IGqlpSchema>();

    // Act
    IResult<IGqlpSchema> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpSchema>>()
      .Required().ShouldNotBeNull()
      .Result.ShouldBe(ParseResultKind.Failure);
  }
}
