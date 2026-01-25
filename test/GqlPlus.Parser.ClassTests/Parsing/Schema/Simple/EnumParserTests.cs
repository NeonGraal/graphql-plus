using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class EnumParserTests : ParserClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly EnumParser<CategoryOption> _parser;

  public EnumParserTests()
    => _parser = new EnumParser<CategoryOption>();

  [Fact]
  public void Parse_ShouldReturnEnum_WhenValid()
  {
    // Arrange
    IdentifierReturns(OutString("Parallel"));

    // Act
    IResult<CategoryOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<CategoryOption>>()
      .Required().ShouldBe(CategoryOption.Parallel);
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue()
  {
    // Arrange
    IdentifierReturns(OutString("InvalidValue"));
    SetupError<CategoryOption>();

    // Act
    IResult<CategoryOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnEmpty_WhenNoIdentifier()
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<CategoryOption> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
