using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Schema.Simple;

public class MergeDomainAstEnumsTests
  : TestDomainAsts<IGqlpDomainLabel, string>
{
  internal override IDomainMerger<IGqlpDomainLabel> Merger { get; }
  internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainLabel>, string, IGqlpDomainLabel> MergerTyped { get; }

  public MergeDomainAstEnumsTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainLabelAst, IGqlpDomainLabel> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    MergerTyped = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainLabel> MakeDomain(string name, string[]? aliases = null, string description = "", string? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainLabel>? items = null)
    => new AstDomain<DomainLabelAst, IGqlpDomainLabel>(AstNulls.At, name, description, kind ?? DomainKind.Enum) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = items?.ArrayOf<DomainLabelAst>() ?? [],
    };

  protected override IGqlpDomainLabel[] MakeItems(string input)
    => new[] { input }.DomainLabels();
}
