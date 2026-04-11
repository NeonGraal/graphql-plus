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
    IResult<IAstUnionMember> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstUnionMember>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);
    SetupError<IAstUnionMember>();

    // Act
    IResult<IAstUnionMember> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
