using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainRegexesTests(ITestOutputHelper outputHelper)
    : TestDomainItemMerger<IAstDomainRegex, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeItem(name, true), MakeAst(name)]);

  private readonly MergeDomainRegexes _merger = new(MergeRepo(outputHelper.ToLoggerFactory()));

  internal override GroupsMerger<IAstDomainRegex> MergerGroups => _merger;

  protected override IAstDomainRegex MakeItem(string input, bool excludes)
    => new DomainRegexAst(AstNulls.At, "", excludes, input);
}
