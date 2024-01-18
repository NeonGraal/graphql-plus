﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseScalarTests(Parser<ScalarDeclAst>.D parser)
    : BaseAliasedTests<ScalarInput>
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
  public void WithReferences_ReturnsCorrectAst(string name, string reference1, string reference2)
    => _checks.TrueExpected(
      name + "{union|" + reference1 + "|" + reference2 + "}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.Union,
        References = reference1.ScalarReferences(reference2),
      });

  [Theory, RepeatData(Repeats)]
  public void WithReferencesBad_ReturnsFalse(string name)
    => _checks.False(name + "{union | }");

  [Theory, RepeatData(Repeats)]
  public void WithReferencesFirstBad_ReturnsFalse(string name, string reference1, string reference2)
    => _checks.False(name + "{union " + reference1 + "|" + reference2 + "}");

  [Theory, RepeatData(Repeats)]
  public void WithReferencesSecondBad_ReturnsFalse(string name, string reference1, string reference2)
    => _checks.False(name + "{union|" + reference1 + " " + reference2 + "}");

  [Theory, RepeatData(Repeats)]
  public void WithRegexes_ReturnsCorrectAst(string name, string regex1, string regex2)
    => _checks.TrueExpected(
      name + "{string/" + regex1 + "/!/" + regex2 + "/}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.String,
        Regexes = regex1.ScalarRegexes(regex2),
      });

  [Theory, RepeatData(Repeats)]
  public void WithRegexesFirstBad_ReturnsFalse(string name)
    => _checks.False(name + "{string/}");

  [Theory, RepeatData(Repeats)]
  public void WithRegexesSecondBad_ReturnsFalse(string name, string regex1, string regex2)
    => _checks.False(name + "{string/" + regex1 + "/!/" + regex2 + "}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeNoBounds_ReturnsFalse(string name)
    => _checks.False(name + "{number ~}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeLowerBound_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number {min}~}}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.Number,
        Ranges = [new(AstNulls.At, min, null)],
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
        Ranges = [new(AstNulls.At, null, max)],
      });

  [Theory, RepeatData(Repeats)]
  public void WithRangeBounds_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks.TrueExpected(
      name + $"{{number {min}~{max}}}",
      new ScalarDeclAst(AstNulls.At, name) {
        Kind = ScalarKind.Number,
        Ranges = [new(AstNulls.At, min, max)],
      },
      max <= min);

  [Theory, RepeatData(Repeats)]
  public void WithRangeBoundsBad_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks.False(
      name + $"{{number ~{max} {min}!}}",
      skipIf: max > min);

  internal override IBaseAliasedChecks<ScalarInput> AliasChecks => _checks;

  private readonly ParseScalarChecks _checks = new(parser);
}

internal sealed class ParseScalarChecks
  : BaseAliasedChecks<ScalarInput, ScalarDeclAst>
{
  public ParseScalarChecks(Parser<ScalarDeclAst>.D parser)
    : base(parser)
  { }

  protected internal override ScalarDeclAst AliasedFactory(ScalarInput input)
    => new(AstNulls.At, input.Name) {
      Kind = ScalarKind.String,
      Regexes = input.Regex.ScalarRegexes(),
    };

  protected internal override string AliasesString(ScalarInput input, string aliases)
    => input.Name + aliases + "{string/" + input.Regex + "/!}";
}

public record struct ScalarInput(string Name, string Regex);
