using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Schema.Simple;

public class MergeDomainAstBooleansTests
  : TestDomainAsts<IGqlpDomainTrueFalse, bool>
{
  internal override IDomainMerger<IGqlpDomainTrueFalse> Merger { get; }
  internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainTrueFalse>, string, IGqlpDomainTrueFalse> MergerTyped { get; }

  public MergeDomainAstBooleansTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainTrueFalseAst, IGqlpDomainTrueFalse> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    Merger = merger;
    MergerTyped = merger;
  }

  protected override IGqlpDomain<IGqlpDomainTrueFalse> MakeDomain(string name, string[]? aliases = null, string description = "", string? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainTrueFalse>? items = null)
    => new AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>(AstNulls.At, name, description, kind ?? DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = items?.ArrayOf<DomainTrueFalseAst>() ?? [],
    };

  protected override IGqlpDomainTrueFalse[] MakeItems(bool input)
    => new[] { input }.DomainTrueFalses();
}
