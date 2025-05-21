using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumLabelTests
  : AliasesClassTestBase
{
  private readonly ParseEnumLabel _parser;

  public ParseEnumLabelTests()
    => _parser = new ParseEnumLabel(Aliases);

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumLabel_WhenValid(string label, string[] aliases)
  {
    // Arrange
    IdentifierReturns(OutString(label));
    ParseAliasesOk(aliases);

    // Act
    IResult<IGqlpEnumLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IGqlpEnumLabel>>();
  }

  [Fact]
  public void Parse_ShouldReturnError_WhenLabelInvalid()
  {
    // Arrange
    IdentifierReturns(OutFail);
    SetupError<IGqlpEnumLabel>();

    // Act
    IResult<IGqlpEnumLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenAliasesFail(string label)
  {
    // Arrange
    IdentifierReturns(OutString(label));
    ParseAliasesError();
    SetupPartial<IGqlpEnumLabel>();

    // Act
    IResult<IGqlpEnumLabel> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IGqlpEnumLabel>>();
  }
}
