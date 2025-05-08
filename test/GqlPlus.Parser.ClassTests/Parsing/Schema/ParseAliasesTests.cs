namespace GqlPlus.Parsing.Schema;

public class ParseAliasesTests
  : ParserClassTestBase
{
  private readonly ParseAliases _parser = new();

  [Theory, RepeatData]
  public void Parse_ShouldReturnAliases_WhenValid(string alias1, string alias2)
  {
    // Arrange
    TakeReturns('[', true, false);
    TakeReturns(']', true, false);
    IdentifierReturns(OutString(alias1), OutString(alias2), OutFail);

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldSatisfyAllConditions(
      r => r.ShouldNotBeNull(),
      r => r.IsOk().ShouldBeTrue(),
      r => r.Required().ShouldNotBeNull()
        .ShouldBe([alias1, alias2]));
  }

  [Theory, RepeatData]
  public void Parse_ShouldReturnError_WhenClosingBracketIsMissing(string alias1, string alias2)
  {
    // Arrange
    TakeReturns('[', true, false);
    TakeReturns(']', false);
    IdentifierReturns(OutString(alias1), OutString(alias2), OutFail);
    SetupPartial("");

    // Act
    IResultArray<string> result = _parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultArrayPartial<string>>();
  }
}
