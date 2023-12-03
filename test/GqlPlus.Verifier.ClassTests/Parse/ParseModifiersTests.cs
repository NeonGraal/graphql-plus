﻿namespace GqlPlus.Verifier.Parse;

public class ParseModifiersTests
{
  [Theory]
  [InlineData("", 0)]
  [InlineData("?", 1)]
  [InlineData("[]", 1)]
  [InlineData("[String]", 1)]
  [InlineData("[~?]", 1)]
  [InlineData("[]?", 2)]
  [InlineData("[_?][]?", 3)]
  public void WithInput_ReturnsGivenNumber(string input, int count)
    => Test.Count(input, count);

  [Fact]
  public void WithFour_ReturnsSpecific()
    => Test.TrueExpected("[~][_?][]?",
      new ModifierAst[] {
        new(AstNulls.At, "~", false),
        new(AstNulls.At, "_", true),
        ModifierAst.List(AstNulls.At),
        ModifierAst.Optional(AstNulls.At),
      });

  private readonly ManyChecksParser<ModifierAst> Test;

  public ParseModifiersTests(Parser<ModifierAst>.DA parser)
    => Test = new(parser);
}
