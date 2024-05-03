﻿namespace GqlPlus.Parse;

public class ParseModifiersTests(Parser<ModifierAst>.DA parser)
{
  [Theory]
  [InlineData("", 0)]
  [InlineData("?", 1)]
  [InlineData("[]", 1)]
  [InlineData("[String]", 1)]
  [InlineData("[^?]", 1)]
  [InlineData("[]?", 2)]
  [InlineData("[_?][]?", 3)]
  public void WithInput_ReturnsGivenNumber(string input, int count)
    => _test.Count(input, count);

  [Fact]
  public void WithFour_ReturnsSpecific()
    => _test.TrueExpected("[^][_?][]?", [
      new(AstNulls.At, new(AstNulls.At, "^"), false),
      new(AstNulls.At, new(AstNulls.At, "_"), true),
      ModifierAst.List(AstNulls.At),
      ModifierAst.Optional(AstNulls.At),
    ]);

  private readonly ManyChecksParser<ModifierAst> _test = new(parser);
}
