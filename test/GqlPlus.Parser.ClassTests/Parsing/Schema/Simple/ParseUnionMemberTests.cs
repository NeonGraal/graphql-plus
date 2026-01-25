using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseUnionMemberTests
  : ParserClassTestBase
{
  private readonly ParseUnionMember _parser;

  public ParseUnionMemberTests()
    => _parser = new ParseUnionMember();

  [Theory, RepeatData]
  public void Parse_ShouldReturnUnionMember_WhenValid(string memberValue, string label)
  {
    // Arrange
    IdentifierReturns(OutString(memberValue));

    // Act
    IResult<IGqlpUnionMember> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpUnionMember>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenInvalid(string label)
  {
    // Arrange
    IdentifierReturns(OutFail);
    SetupError<IGqlpUnionMember>();

    // Act
    IResult<IGqlpUnionMember> result = _parser.Parse(Tokenizer, label);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}
