using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainMembersTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<IGqlpDomainMember>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([
      MakeAst(name) with { Excludes = true },
      MakeAst(name)]);

  private readonly MergeDomainMembers _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainMember> MergerGroups => _merger;

  protected override DomainMemberAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
