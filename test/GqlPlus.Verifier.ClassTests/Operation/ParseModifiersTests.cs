using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

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
        new("~", false),
        new("_", true),
        ModifierAst.List,
        ModifierAst.Optional
      });

  private static BaseArrayChecks<ModifierAst> Test => new((ref OperationParser parser)
    => parser.ParseModifiers());
}
