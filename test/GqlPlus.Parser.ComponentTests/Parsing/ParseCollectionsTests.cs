namespace GqlPlus.Parsing;

public class ParseCollectionsTests(ParserArray<IParserCollections, IGqlpModifier>.DA parser)
{
  [Theory]
  [InlineData("", 0)]
  [InlineData("[]", 1)]
  [InlineData("[String]", 1)]
  [InlineData("[^?]", 1)]
  public void WithInput_ReturnsGivenNumber(string input, int count)
    => _test.Count(input, count);

  [Fact]
  public void WithThree_ReturnsSpecific()
    => _test.TrueExpected("[^][_?][]", [
      ModifierAst.Dict(AstNulls.At, "^", false),
      ModifierAst.Dict(AstNulls.At, "_", true),
      ModifierAst.List(AstNulls.At),
    ]);

  private readonly ManyChecksParser<IParserCollections, IGqlpModifier> _test = new(parser);
}
