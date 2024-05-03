﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parse.Schema.Simple;

public sealed class ParseDomainNumberTests(
  Parser<IGqlpDomain>.D parser
) : BaseDomainTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithRangeNoBounds_ReturnsFalse(string name)
    => _checks.False(name + "{number ~}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeLowerBound_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number {min}>}}",
      new AstDomain<DomainRangeAst>(AstNulls.At, name, DomainKind.Number, [new(AstNulls.At, false, min, null)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeSingle_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number {min}}}",
      new AstDomain<DomainRangeAst>(AstNulls.At, name, DomainKind.Number, [new(AstNulls.At, false, min, min)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeExcludes_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number !{min}}}",
      new AstDomain<DomainRangeAst>(AstNulls.At, name, DomainKind.Number, [new(AstNulls.At, true, min, min)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeUpperBound_ReturnsCorrectAst(string name, decimal max)
    => _checks.TrueExpected(
      name + $"{{number <{max}}}",
      new AstDomain<DomainRangeAst>(AstNulls.At, name, DomainKind.Number, [new(AstNulls.At, false, null, max)]));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithRangeBounds_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks.TrueExpected(
      name + $"{{number {min}~{max}}}",
      new AstDomain<DomainRangeAst>(AstNulls.At, name, DomainKind.Number, [new(AstNulls.At, false, min, max)]),
      skipIf: max <= min);

  [SkippableTheory, RepeatData(Repeats)]
  public void WithRangeBoundsBad_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks.False(
      name + $"{{number ~{max} {min}!}}",
      skipIf: max > min);

  internal override IBaseDomainChecks<string> DomainChecks => _checks;

  private readonly ParseDomainNumberChecks _checks = new(parser);
}

internal sealed class ParseDomainNumberChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<string, AstDomain>(parser, DomainKind.Number)
{
  protected internal override AstDomain<DomainRangeAst> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Number, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{number }";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}
