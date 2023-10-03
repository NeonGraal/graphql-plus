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
  {
    var parser = new OperationParser(Tokens(input));

    ModifierAst[] result = parser.ParseModifiers();

    result.Length.Should().Be(count);
  }

  [Fact]
  public void WithThree_ReturnsSpecific()
  {
    var parser = new OperationParser(Tokens("[_?][]?"));
    var expected = new ModifierAst[] {
        new() { Key = "_", KeyOptional = true},
        ModifierAst.List,
        ModifierAst.Optional
      };

    ModifierAst[] result = parser.ParseModifiers();

    result.Should().Equal(expected);
  }
}
