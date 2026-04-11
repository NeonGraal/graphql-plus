using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class ParseEnumLabelTests
  : AliasesClassTestBase
{

  private readonly ParseEnumLabel _parser;

  public ParseEnumLabelTests()
    => _parser = new ParseEnumLabel(Parsers);

  [Theory, RepeatData]
  public void Parse_ShouldReturnEnumLabel_WhenValid(string[] aliases, string parseLabel)
  {
    // Arrange
    IdentifierReturns(OutString(TestLabel));
    ParseAliasesOk(aliases);

    // Act
    IResult<IAstEnumLabel> result = _parser.Parse(Tokenizer, parseLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultOk<IAstEnumLabel>>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenLabelInvalid(string parseLabel)
  {
    // Arrange
    IdentifierReturns(OutFail);
    SetupError<IAstEnumLabel>();

    // Act
    IResult<IAstEnumLabel> result = _parser.Parse(Tokenizer, parseLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnPartial_WhenAliasesFail(string parseLabel)
  {
    // Arrange
    IdentifierReturns(OutString(TestLabel));
    ParseAliasesError();
    SetupPartial<IAstEnumLabel>();

    // Act
    IResult<IAstEnumLabel> result = _parser.Parse(Tokenizer, parseLabel);

    // Assert
    result.ShouldBeAssignableTo<IResultPartial<IAstEnumLabel>>();
  }
}
