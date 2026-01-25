using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumLabelTests
  : AliasesClassTestBase
{
  private const string TestLabel = "testLabel";

  private readonly ParseEnumLabel _parser;

  public ParseEnumLabelTests()
    => _parser = new ParseEnumLabel(Aliases);

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumLabel_WhenValid(string[] aliases, string parseLabel)
  {
    // Arrange
    IdentifierReturns(OutString(TestLabel));
    ParseAliasesOk(aliases);

    // Act
    IResult<IGqlpEnumLabel> result = _parser.Parse(Tokenizer, parseLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenLabelInvalid(string parseLabel)
  {
    // Arrange
    IdentifierReturns(OutFail);
    SetupError<IGqlpEnumLabel>();

    // Act
    IResult<IGqlpEnumLabel> result = _parser.Parse(Tokenizer, parseLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenAliasesFail(string parseLabel)
  {
    // Arrange
    IdentifierReturns(OutString(TestLabel));
    ParseAliasesError();
    SetupPartial<IGqlpEnumLabel>();

    // Act
    IResult<IGqlpEnumLabel> result = _parser.Parse(Tokenizer, parseLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpEnumLabel>>();
  }
}
