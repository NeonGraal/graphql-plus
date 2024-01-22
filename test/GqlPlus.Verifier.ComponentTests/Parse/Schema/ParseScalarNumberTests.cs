﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarNumberTests(Parser<ScalarDeclAst>.D parser)
    : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => _checks.False($"{id}{{String}}");

  [Theory, RepeatData(Repeats)]
  public void WithKindBad_ReturnsFalse(string name, string kind)
    => _checks.False(
      $"{name}{{{kind}}}",
      skipIf: Enum.TryParse<ScalarKind>(kind, out var _));

  [Theory, RepeatData(Repeats)]
  public void WithRangeNoBounds_ReturnsFalse(string name)
    => _checks.False(name + "{number ~}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeLowerBound_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number {min}~}}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.Number,
        Numbers = [new(AstNulls.At, min, null)],
      });

  [Theory, RepeatData(Repeats)]
  public void WithRangeLowerBoundBad_ReturnsFalse(string name, decimal min)
    => _checks.False(name + $"{{number {min}}}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeUpperBound_ReturnsCorrectAst(string name, decimal max)
    => _checks.TrueExpected(
      name + $"{{number ~{max}}}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.Number
        ,
        Numbers = [new(AstNulls.At, null, max)],
      });

  [Theory, RepeatData(Repeats)]
  public void WithRangeBounds_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks.TrueExpected(
      name + $"{{number {min}~{max}}}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.Number,
        Numbers = [new(AstNulls.At, min, max)],
      },
      max <= min);

  [Theory, RepeatData(Repeats)]
  public void WithRangeBoundsBad_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks.False(
      name + $"{{number ~{max} {min}!}}",
      skipIf: max > min);

  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseScalarNumberChecks _checks = new(parser);
}

internal sealed class ParseScalarNumberChecks
  : BaseAliasedChecks<string, ScalarDeclAst>
{
  public ParseScalarNumberChecks(Parser<ScalarDeclAst>.D parser)
    : base(parser)
  { }

  protected internal override ScalarDeclAst AliasedFactory(string input)
    => new(AstNulls.At, input) {
      Kind = ScalarKind.Number,
      Numbers = [],
    };

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{number }";
}
