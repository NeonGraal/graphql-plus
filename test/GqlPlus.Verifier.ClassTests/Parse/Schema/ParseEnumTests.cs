using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseEnumTests
  : BaseAliasedTests<EnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(EnumInput input, string extends)
    => Test.TrueExpected(input.Name + "{:" + extends + " " + input.Label + "}",
      Test.AliasedFactory(input) with {
        Extends = extends,
      });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsBad_ReturnsFalse(string name, string extends, string label)
    => Test.False(name + "{:" + extends + label + "}");

  [Theory, RepeatData(Repeats)]
  public void WithLabels_ReturnsCorrectAst(string name, string[] labels)
    => Test.TrueExpected(
      name + labels.Bracket("{", "}").Joined(),
      new EnumAst(AstNulls.At, name) {
        Labels = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithLabelsBad_ReturnsFalse(string name, string[] labels)
    => Test.False(name + "{" + string.Join("|", labels) + "}",
      skipIf: labels.Length < 2);

  private static ParseEnumChecks Test => new();

  internal override IBaseAliasedChecks<EnumInput> AliasChecks => Test;
}
