using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseDomainNumberTests(
  IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainRange>> checks
) : BaseDomainTests<string, IGqlpDomain<IGqlpDomainRange>>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithRangeNoBounds_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{number ~}");

  [Theory, RepeatData(Repeats)]
  public void WithRangeLowerBound_ReturnsCorrectAst(string name, decimal min)
    => checks.TrueExpected(
      name + $"{{number {min}>}}",
      NewDomain(name, [NewRange(min, null)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeSingle_ReturnsCorrectAst(string name, decimal min)
    => checks.TrueExpected(
      name + $"{{number {min}}}",
      NewDomain(name, [NewRange(min, min)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeExcludes_ReturnsCorrectAst(string name, decimal min)
    => checks.TrueExpected(
      name + $"{{number !{min}}}",
      NewDomain(name, [new(AstNulls.At, true, min, min)]));

  [Theory, RepeatData(Repeats)]
  public void WithRangeUpperBound_ReturnsCorrectAst(string name, decimal max)
    => checks.TrueExpected(
      name + $"{{number <{max}}}",
      NewDomain(name, [NewRange(null, max)]));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithRangeBounds_ReturnsCorrectAst(string name, decimal min, decimal max)
    => checks
      .SkipIf(max <= min)
      .TrueExpected(
        name + $"{{number {min}~{max}}}",
        NewDomain(name, [NewRange(min, max)]));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithRangeBoundsBad_ReturnsCorrectAst(string name, decimal min, decimal max)
    => checks
      .SkipIf(max > min)
      .FalseExpected(
        name + $"{{number ~{max} {min}!}}");

  private static AstDomain<DomainRangeAst, IGqlpDomainRange> NewDomain(string name, DomainRangeAst[] members)
    => new(AstNulls.At, name, DomainKind.Number, members);

  private static DomainRangeAst NewRange(decimal? min, decimal? max)
    => new(AstNulls.At, false, min, max);
}

internal sealed class ParseDomainNumberChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<string, AstDomain<DomainRangeAst, IGqlpDomainRange>, IGqlpDomain<IGqlpDomainRange>>(parser, DomainKind.Number)
{
  protected internal override AstDomain<DomainRangeAst, IGqlpDomainRange> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Number, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{number }";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}
