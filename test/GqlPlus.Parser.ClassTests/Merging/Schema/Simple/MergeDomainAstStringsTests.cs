using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstStringsTests
  : TestDomainMerger<IGqlpDomainRegex, string>
{
  internal override IDomainMerger<IGqlpDomainRegex> Merger { get; }
  internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainRegex>, string, IGqlpDomainRegex> MergerTyped { get; }

  public MergeDomainAstStringsTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainRegexAst, IGqlpDomainRegex> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    MergerTyped = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainRegex> MakeDomain(string name, string[]? aliases = null, string description = "", string? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainRegex>? items = null)
    => new AstDomain<DomainRegexAst, IGqlpDomainRegex>(AstNulls.At, name, description, kind ?? DomainKind.String) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = items?.ArrayOf<DomainRegexAst>() ?? [],
    };

  protected override IGqlpDomainRegex[] MakeItems(string input)
    => new[] { input }.DomainRegexes();
}
