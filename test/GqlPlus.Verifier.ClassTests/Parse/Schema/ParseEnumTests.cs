using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseEnumTests
  : BaseAliasedTests<EnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id, string label)
    => _test.False($"{id}{{{label}}}");

  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(EnumInput input, string extends)
    => _test.TrueExpected(input.Name + "{:" + extends + " " + input.Label + "}",
      _test.AliasedFactory(input) with {
        Extends = extends,
      });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsBad_ReturnsFalse(string name)
    => _test.False(name + "{:}");

  [Theory, RepeatData(Repeats)]
  public void WithLabels_ReturnsCorrectAst(string name, string[] labels)
    => _test.TrueExpected(
      name + labels.Bracket("{", "}").Joined(),
      new EnumAst(AstNulls.At, name) {
        Labels = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithLabelsBad_ReturnsFalse(string name, string[] labels)
    => _test.False(name + "{" + string.Join("|", labels) + "}",
      skipIf: labels.Length < 2);

  [Theory, RepeatData(Repeats)]
  public void WithLabelsNone_ReturnsFalse(string name)
    => _test.False(name + "{}");

  internal override IBaseAliasedChecks<EnumInput> AliasChecks => _test;

  private readonly ParseEnumChecks _test;

  public ParseEnumTests(Parser<EnumAst>.D parser)
    => _test = new(parser);
}
