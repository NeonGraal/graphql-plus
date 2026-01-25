using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class ParseTypeRefTests
  : ParserClassTestBase
{

  private readonly ParseTypeRef _parser = new();

  [Theory, RepeatData]
  public void Parse_ShouldReturnTypeRef_WhenIdentifierIsValid(string typeName)
  {
    // Arrange
    IdentifierReturns(OutString(typeName));

    // Act
    IResult<IGqlpTypeRef> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.ShouldNotBeNull()
        .IsOk().ShouldBeTrue(),
      r => r.Required().ShouldNotBeNull()
        .Name.ShouldBe(typeName));
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenIdentifierIsInvalid()
  {
    // Arrange
    SetupError<IGqlpTypeRef>();

    // Act
    IResult<IGqlpTypeRef> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
