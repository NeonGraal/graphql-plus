using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarTests
  : BaseAliasedTests<ScalarInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => Test.False($"{id}{{String}}");

  [Theory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(string name, string kind)
    => Test.False(
      $"{name}{{{kind}}}",
      skipIf: Enum.TryParse<ScalarKind>(kind, out var _));

  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(string name, string regex1, string regex2)
    => Test.TrueExpected(
      name + "{string/" + regex1 + "/!/" + regex2 + "/}",
      new ScalarAst(AstNulls.At, name) {
        Kind = ScalarKind.String,
        Regexes = regex1.ScalarRegexes(regex2),
      });

  [Theory, RepeatData(Repeats)]
  public void WithRegexesBad_ReturnsCorrectAst(string name, string regex1, string regex2)
    => Test.False(name + "{string/" + regex1 + "/!/" + regex2 + "}");

  [Theory, RepeatData(Repeats)]
  public void WithNoBounds_ReturnsFalse(string name)
    => Test.False(name + "{number ..}");

  [Theory, RepeatData(Repeats)]
  public void WithLowerBound_ReturnsCorrectAst(string name, decimal min)
    => Test.TrueExpected(
      name + $"{{number {min}..}}",
      new ScalarAst(AstNulls.At, name) {
        Kind = ScalarKind.Number,
        Ranges = new ScalarRangeAst[] { new(AstNulls.At, min, null) },
      });

  [Theory, RepeatData(Repeats)]
  public void WithLowerBoundBad_ReturnsFalse(string name, decimal min)
    => Test.False(name + $"{{number {min}}}");

  [Theory, RepeatData(Repeats)]
  public void WithUpperBound_ReturnsCorrectAst(string name, decimal max)
    => Test.TrueExpected(
      name + $"{{number ..{max}}}",
      new ScalarAst(AstNulls.At, name) {
        Kind = ScalarKind.Number
        ,
        Ranges = new ScalarRangeAst[] { new(AstNulls.At, null, max) },
      });

  [Theory, RepeatData(Repeats)]
  public void WithRangeBounds_ReturnsCorrectAst(string name, decimal min, decimal max)
    => Test.TrueExpected(
      name + $"{{number {min}>..<{max}}}",
      new ScalarAst(AstNulls.At, name) {
        Kind = ScalarKind.Number,
        Ranges = new ScalarRangeAst[] { new(AstNulls.At, min, max) {
          LowerExcluded = true, UpperExcluded = true,
        } },
      },
      max <= min);

  [Theory, RepeatData(Repeats)]
  public void WithRangeBoundsBad_ReturnsCorrectAst(string name, decimal min, decimal max)
    => Test.False(
      name + $"{{number ..<{max} {min}>}}",
      skipIf: max > min);

  private static ParseScalarChecks Test => new();

  internal override IBaseAliasedChecks<ScalarInput> AliasChecks => Test;
}
