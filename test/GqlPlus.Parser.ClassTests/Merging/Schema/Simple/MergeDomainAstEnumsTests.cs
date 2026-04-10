using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstEnumsTests
  : TestDomainMerger<IGqlpDomainLabel, string>
{
  internal override IDomainMerger<IGqlpDomainLabel> Merger { get; }
  internal override AstSimpleMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainLabel>, IGqlpDomainLabel> MergerSimple { get; }

  public MergeDomainAstEnumsTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpDomainLabel>().Returns(MergeItems);
    MergeDomains<DomainLabelAst, IGqlpDomainLabel> merger = new(mergers);
    MergerSimple = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainLabel> MakeDomain(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainLabel>? items = null)
    => new AstDomain<DomainLabelAst, IGqlpDomainLabel>(AstNulls.At, name, description, kind ?? DomainKind.Enum) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IGqlpDomainLabel[] MakeItems(string input)
    => new[] { input }.DomainLabels();
}
