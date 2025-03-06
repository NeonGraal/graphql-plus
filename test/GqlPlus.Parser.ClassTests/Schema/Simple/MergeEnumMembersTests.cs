using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Schema.Simple;

public class MergeEnumMembersTests(
  ITestOutputHelper outputHelper
) : TestAliased<IGqlpEnumItem>
{
  private readonly MergeEnumMembers _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpEnumItem> MergerGroups => _merger;

  protected override IGqlpEnumItem MakeAliased(string name, string[]? aliases = null, string description = "")
    => new EnumMemberAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
