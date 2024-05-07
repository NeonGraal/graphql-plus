using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumTypes(
  IVerifyAliased<IGqlpEnum> aliased,
  IMerge<IGqlpEnumItem> mergeMembers
) : AstParentItemVerifier<IGqlpEnum, string, UsageContext, IGqlpEnumItem>(aliased, mergeMembers)
{
  protected override IEnumerable<IGqlpEnumItem> GetItems(IGqlpEnum usage)
    => usage.Items;

  protected override string GetParent(IGqlpType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(IGqlpEnum usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);
}
