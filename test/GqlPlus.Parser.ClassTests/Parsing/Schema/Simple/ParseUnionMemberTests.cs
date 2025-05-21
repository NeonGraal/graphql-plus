using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseUnionMemberTests
  : ParserClassTestBase
{
  private readonly ParseUnionMember _parser;

  public ParseUnionMemberTests()
    => _parser = new ParseUnionMember();

  [Theory, RepeatData]
  public void Parse_ShouldReturnUnionMember_WhenValid(string memberValue)
  {
    // Arrange
    IdentifierReturns(OutString(memberValue));

    // Act
    IResult<IGqlpUnionMember> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpUnionMember>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);
    SetupError<IGqlpUnionMember>();

    // Act
    IResult<IGqlpUnionMember> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
