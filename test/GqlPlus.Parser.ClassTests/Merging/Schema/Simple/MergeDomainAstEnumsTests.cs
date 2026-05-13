using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstEnumsTests
  : TestDomainMerger<IAstDomainLabel, string>
{
  internal override IDomainMerger<IAstDomainLabel> Merger { get; }
  internal override AstSimpleMerger<IAstDomain, IAstDomain<IAstDomainLabel>, IAstDomainLabel> MergerSimple { get; }

  public MergeDomainAstEnumsTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerForReturns(MergeItems);
    MergeDomains<DomainLabelAst, IAstDomainLabel> merger = new(mergers);
    MergerSimple = merger;
    Merger = merger;
  }

  protected override IAstDomain<IAstDomainLabel> MakeDomain(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IAstDomainLabel>? items = null)
    => new AstDomain<DomainLabelAst, IAstDomainLabel>(AstNulls.At, name, description, kind ?? DomainKind.Enum) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IAstDomainLabel[] MakeItems(string input)
    => new[] { input }.DomainLabels();
}
