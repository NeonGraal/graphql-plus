namespace GqlPlus.Parsing;

public class ParseCollectionsTests(
  IManyChecksParser<IParserCollections, IGqlpModifier> checks
)
{
  [Theory]
  [InlineData("", 0)]
  [InlineData("[]", 1)]
  [InlineData("[String]", 1)]
  [InlineData("[^?]", 1)]
  [InlineData("[0][_][*?]", 3)]
  public void WithInput_ReturnsGivenNumber(string input, int count)
    => checks.Count(input, count);

  [Fact]
  public void WithThree_ReturnsSpecific()
    => checks.TrueExpected("[^][_?][]", [
      ModifierAst.Dict(AstNulls.At, "^", false),
      ModifierAst.Dict(AstNulls.At, "_", true),
      ModifierAst.List(AstNulls.At),
    ]);
}
