using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumMembers
  : AstAliasedMerger<EnumMemberAst>
{
  protected override string ItemMatchKey(EnumMemberAst item)
    => item.Name;
}
