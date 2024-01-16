using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeEnumMembersTests
  : TestAliased<EnumMemberAst>
{
  private readonly MergeEnumMembers _merger = new();

  protected override GroupsMerger<EnumMemberAst> MergerGroups => _merger;

  protected override EnumMemberAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
