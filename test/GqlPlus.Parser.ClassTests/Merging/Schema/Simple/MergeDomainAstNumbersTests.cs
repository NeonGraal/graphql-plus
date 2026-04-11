using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstNumbersTests
  : TestDomainMerger<IAstDomainRange, DomainRangeInput>
{
  internal override IDomainMerger<IAstDomainRange> Merger { get; }
  internal override AstSimpleMerger<IAstDomain, IAstDomain<IAstDomainRange>, IAstDomainRange> MergerSimple { get; }

  public MergeDomainAstNumbersTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstDomainRange>().Returns(MergeItems);
    MergeDomains<DomainRangeAst, IAstDomainRange> merger = new(mergers);
    MergerSimple = merger;
    Merger = merger;
  }

  protected override IAstDomain<IAstDomainRange> MakeDomain(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IAstDomainRange>? items = null)
    => new AstDomain<DomainRangeAst, IAstDomainRange>(AstNulls.At, name, description, kind ?? DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IAstDomainRange[] MakeItems(DomainRangeInput input)
    => [new DomainRangeAst(AstNulls.At, "", false, input.Lower, input.Upper)];
}
