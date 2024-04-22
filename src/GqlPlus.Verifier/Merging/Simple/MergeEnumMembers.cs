using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Merging.Simple;

internal class MergeEnumMembers(
  ILoggerFactory logger
) : AstAliasedMerger<EnumMemberAst>(logger)
{
  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(EnumMemberAst item)
    => item.Name;
}
