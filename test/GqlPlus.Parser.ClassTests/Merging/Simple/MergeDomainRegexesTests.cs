using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainRegexesTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<IGqlpDomainRegex>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeAst(name) with { Excludes = true }, MakeAst(name)]);

  private readonly MergeDomainRegexes _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainRegex> MergerGroups => _merger;

  protected override DomainRegexAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
