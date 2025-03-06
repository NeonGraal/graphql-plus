using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Schema.Simple;

public class MergeDomainRegexesTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<IGqlpDomainRegex, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeItem(name, true), MakeAst(name)]);

  private readonly MergeDomainRegexes _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainRegex> MergerGroups => _merger;

  protected override IGqlpDomainRegex MakeItem(string input, bool excludes)
    => new DomainRegexAst(AstNulls.At, excludes, input);
}
