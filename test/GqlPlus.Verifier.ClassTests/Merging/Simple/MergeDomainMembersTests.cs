using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Merging.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Types;

public class MergeDomainMembersTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<DomainMemberAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([
      MakeAst(name) with { Excludes = true },
      MakeAst(name)]);

  private readonly MergeDomainMembers _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<DomainMemberAst> MergerGroups => _merger;

  protected override DomainMemberAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
