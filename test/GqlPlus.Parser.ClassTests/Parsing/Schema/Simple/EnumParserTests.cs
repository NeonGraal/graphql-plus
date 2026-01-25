using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class EnumParserTests : ParserClassTestBase
{
  private readonly EnumParser<CategoryOption> _parser;

  public EnumParserTests()
    => _parser = new EnumParser<CategoryOption>();

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnum_WhenValid(string label)
  {
    // Arrange
    IdentifierReturns(OutString("Parallel"));

    // Act
    IResult<CategoryOption> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<CategoryOption>>()
      .Required().ShouldBe(CategoryOption.Parallel);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalidEnumValue(string label)
  {
    // Arrange
    IdentifierReturns(OutString("InvalidValue"));
    SetupError<CategoryOption>();

    // Act
    IResult<CategoryOption> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnEmpty_WhenNoIdentifier(string label)
  {
    // Arrange
    IdentifierReturns(OutFail);

    // Act
    IResult<CategoryOption> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultEmpty>();
  }
}
