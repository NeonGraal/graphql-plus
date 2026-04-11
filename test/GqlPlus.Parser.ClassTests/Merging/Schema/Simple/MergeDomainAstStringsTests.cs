using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstStringsTests
  : TestDomainMerger<IAstDomainRegex, string>
{
  internal override IDomainMerger<IAstDomainRegex> Merger { get; }
  internal override AstSimpleMerger<IAstDomain, IAstDomain<IAstDomainRegex>, IAstDomainRegex> MergerSimple { get; }

  public MergeDomainAstStringsTests(ITestOutputHelper outputHelper)
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstDomainRegex>().Returns(MergeItems);
    MergeDomains<DomainRegexAst, IAstDomainRegex> merger = new(mergers);
    MergerSimple = merger;
    Merger = merger;
  }

  protected override IAstDomain<IAstDomainRegex> MakeDomain(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, DomainKind? kind = null, IEnumerable<IAstDomainRegex>? items = null)
    => new AstDomain<DomainRegexAst, IAstDomainRegex>(AstNulls.At, name, description, kind ?? DomainKind.String) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = [.. items ?? []],
    };

  protected override IAstDomainRegex[] MakeItems(string input)
    => new[] { input }.DomainRegexes();
}
