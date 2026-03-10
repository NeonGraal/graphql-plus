using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstNumbersTests
  : TestDomainMerger<IGqlpDomainRange, DomainRangeInput>
{
  internal override IDomainMerger<IGqlpDomainRange> Merger { get; }
  internal override AstSimpleMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainRange>, IGqlpDomainRange> MergerSimple { get; }

  public MergeDomainAstNumbersTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpDomainRange>().Returns(MergeItems);
    MergeDomains<DomainRangeAst, IGqlpDomainRange> merger = new(mergers);
    MergerSimple = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainRange> MakeDomain(string name, string[]? aliases = null, string description = "", IGqlpTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainRange>? items = null)
    => new AstDomain<DomainRangeAst, IGqlpDomainRange>(AstNulls.At, name, description, kind ?? DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IGqlpDomainRange[] MakeItems(DomainRangeInput input)
    => [new DomainRangeAst(AstNulls.At, "", false, input.Lower, input.Upper)];
}
