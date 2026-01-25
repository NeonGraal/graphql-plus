using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseUnionDefinitionTests
  : SimpleParserClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly Parser<IGqlpUnionMember>.I _unionMemberParser;
  private readonly ParseUnionDefinition _parser;

  public ParseUnionDefinitionTests()
  {
    Parser<IGqlpUnionMember>.D unionMemberParser = ParserFor(out _unionMemberParser);
    _parser = new ParseUnionDefinition(TypeRef, unionMemberParser);
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnOk_WhenValid(string parentType)
  {
    // Arrange
    TakeReturns(':', true);
    ParseTypeRefOk(parentType);
    ParseOk(_unionMemberParser);
    TakeReturns('}', false, true);

    // Act
    IResult<UnionDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<UnionDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenParentTypeInvalid()
  {
    // Arrange
    TakeReturns(':', true);
    Tokenizer.Identifier(out _).Returns(false);
    SetupError<UnionDefinition>();

    // Act
    IResult<UnionDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Fact]
  public void Parse_ShouldReturnPartial_WhenMemberErrors()
  {
    // Arrange
    TakeReturns(':', false);
    ParseError(_unionMemberParser);
    SetupPartial(new UnionDefinition());

    // Act
    IResult<UnionDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<UnionDefinition>>();
  }

  [Fact]
  public void Parse_ShouldReturnOk_WhenNoMembers()
  {
    // Arrange
    TakeReturns(':', false);
    TakeReturns('}', true);
    SetupPartial(new UnionDefinition());

    // Act
    IResult<UnionDefinition> result = _parser.Parse(Tokenizer, TestLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<UnionDefinition>>();
  }
}
