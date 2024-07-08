﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseDomainNumberTests(
  Parser<IGqlpDomain>.D parser
) : BaseDomainTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithRangeNoBounds_ReturnsFalse(string name)
    => _checks.FalseExpected(name + "{number ~}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeLowerBound_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number {min}>}}",
      NewDomain(name, [new(AstNulls.At, false, min, null)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeSingle_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number {min}}}",
      NewDomain(name, [new(AstNulls.At, false, min, min)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeExcludes_ReturnsCorrectAst(string name, decimal min)
    => _checks.TrueExpected(
      name + $"{{number !{min}}}",
      NewDomain(name, [new(AstNulls.At, true, min, min)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeUpperBound_ReturnsCorrectAst(string name, decimal max)
    => _checks.TrueExpected(
      name + $"{{number <{max}}}",
      NewDomain(name, [new(AstNulls.At, false, null, max)]));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithRangeBounds_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks
      .SkipIf(max <= min)
      .TrueExpected(
        name + $"{{number {min}~{max}}}",
        NewDomain(name, [new(AstNulls.At, false, min, max)]));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithRangeBoundsBad_ReturnsCorrectAst(string name, decimal min, decimal max)
    => _checks
      .SkipIf(max > min)
      .FalseExpected(
        name + $"{{number ~{max} {min}!}}");

  internal override IBaseDomainChecks<string> DomainChecks => _checks;

  private readonly ParseDomainNumberChecks _checks = new(parser);

  private static AstDomain<DomainRangeAst, IGqlpDomainRange> NewDomain(string name, DomainRangeAst[] members)
    => new(AstNulls.At, name, DomainKind.Number, members);
}

internal sealed class ParseDomainNumberChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<string, AstDomain>(parser, DomainKind.Number)
{
  protected internal override AstDomain<DomainRangeAst, IGqlpDomainRange> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Number, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{number }";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}
