using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeEnumMembersTests(
  ITestOutputHelper outputHelper
) : TestAliased<EnumMemberAst>
{
  private readonly MergeEnumMembers _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<EnumMemberAst> MergerGroups => _merger;

  protected override EnumMemberAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
