using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstBooleansTests
  : TestDomainMerger<IGqlpDomainTrueFalse, bool>
{
  internal override IDomainMerger<IGqlpDomainTrueFalse> Merger { get; }
  internal override AstSimpleMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainTrueFalse>, IGqlpDomainTrueFalse> MergerSimple { get; }

  public MergeDomainAstBooleansTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    Merger = merger;
    MergerSimple = merger;
  }

  protected override IGqlpDomain<IGqlpDomainTrueFalse> MakeDomain(string name, string[]? aliases = null, string description = "", IGqlpTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainTrueFalse>? items = null)
    => new AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>(AstNulls.At, name, description, kind ?? DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IGqlpDomainTrueFalse[] MakeItems(bool input)
    => new[] { input }.DomainTrueFalses();
}
