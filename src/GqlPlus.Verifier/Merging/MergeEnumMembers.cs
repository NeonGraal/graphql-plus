using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumMembers(
  ILoggerFactory logger
) : AstAliasedMerger<EnumMemberAst>(logger)
{
  protected override string ItemMatchKey(EnumMemberAst item)
    => item.Name;
}
