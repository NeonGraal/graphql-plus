using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.Common;

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
    => Test.Expected("[~][_?][]?",
      new ModifierAst[] {
        new(AstNulls.At, "~", false),
        new(AstNulls.At, "_", true),
        ModifierAst.List(AstNulls.At),
        ModifierAst.Optional(AstNulls.At),
      });

  private static ArrayChecks<CommonParser, ModifierAst> Test => new(
    tokens => new CommonParser(tokens),
    parser => {
      var modifiers = parser.ParseModifiers("Modifiers");
      modifiers.Optional(out var value);
      return value ?? Array.Empty<ModifierAst>();
    });
}
