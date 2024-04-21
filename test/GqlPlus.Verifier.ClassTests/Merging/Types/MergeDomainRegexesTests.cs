using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Types;

public class MergeDomainRegexesTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<DomainRegexAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeAst(name) with { Excludes = true }, MakeAst(name)]);

  private readonly MergeDomainRegexes _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<DomainRegexAst> MergerGroups => _merger;

  protected override DomainRegexAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
