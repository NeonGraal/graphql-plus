using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstStringsTests
  : TestDomainMerger<IGqlpDomainRegex, string>
{
  internal override IDomainMerger<IGqlpDomainRegex> Merger { get; }
  internal override AstSimpleMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainRegex>, IGqlpDomainRegex> MergerSimple { get; }

  public MergeDomainAstStringsTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IGqlpDomainRegex>().Returns(MergeItems);
    MergeDomains<DomainRegexAst, IGqlpDomainRegex> merger = new(mergers);
    MergerSimple = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainRegex> MakeDomain(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainRegex>? items = null)
    => new AstDomain<DomainRegexAst, IGqlpDomainRegex>(AstNulls.At, name, description, kind ?? DomainKind.String) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IGqlpDomainRegex[] MakeItems(string input)
    => new[] { input }.DomainRegexes();
}
