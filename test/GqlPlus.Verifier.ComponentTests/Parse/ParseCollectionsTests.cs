namespace GqlPlus.Verifier.Parse;

public class ParseCollectionsTests(ParserArray<IParserCollections, ModifierAst>.DA parser)
{
  [Theory]
  [InlineData("", 0)]
  [InlineData("[]", 1)]
  [InlineData("[String]", 1)]
  [InlineData("[~?]", 1)]
  public void WithInput_ReturnsGivenNumber(string input, int count)
    => _test.Count(input, count);

  [Fact]
  public void WithThree_ReturnsSpecific()
    => _test.TrueExpected("[~][_?][]", [
      new(AstNulls.At, "~", false),
      new(AstNulls.At, "_", true),
      ModifierAst.List(AstNulls.At),
    ]);

  private readonly ManyChecksParser<IParserCollections, ModifierAst> _test = new(parser);
}
