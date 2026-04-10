using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstBooleansTests
  : TestDomainMerger<IAstDomainTrueFalse, bool>
{
  internal override IDomainMerger<IAstDomainTrueFalse> Merger { get; }
  internal override AstSimpleMerger<IAstDomain, IAstDomain<IAstDomainTrueFalse>, IAstDomainTrueFalse> MergerSimple { get; }

  public MergeDomainAstBooleansTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstDomainTrueFalse>().Returns(MergeItems);
    MergeDomains<DomainTrueFalseAst, IAstDomainTrueFalse> merger = new(mergers);
    Merger = merger;
    MergerSimple = merger;
  }

  protected override IAstDomain<IAstDomainTrueFalse> MakeDomain(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IAstDomainTrueFalse>? items = null)
    => new AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse>(AstNulls.At, name, description, kind ?? DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IAstDomainTrueFalse[] MakeItems(bool input)
    => new[] { input }.DomainTrueFalses();
}
