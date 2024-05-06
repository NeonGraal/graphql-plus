using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyEnumTypes(
  IVerifyAliased<IGqlpEnum> aliased,
  IMerge<EnumMemberAst> mergeMembers
) : AstParentItemVerifier<IGqlpEnum, string, UsageContext, EnumMemberAst>(aliased, mergeMembers)
{
  protected override IEnumerable<EnumMemberAst> GetItems(IGqlpEnum usage)
    => usage.Items.ArrayOf<EnumMemberAst>();

  protected override string GetParent(IGqlpType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(IGqlpEnum usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);
}
