using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumTypes(
  IVerifyAliased<IGqlpEnum> aliased,
  IMerge<IGqlpEnumLabel> mergeLabels
) : AstParentItemVerifier<IGqlpEnum, string, UsageContext, IGqlpEnumLabel>(aliased, mergeLabels)
{
  protected override IEnumerable<IGqlpEnumLabel> GetItems(IGqlpEnum usage)
    => usage.Items;

  protected override string GetParent(IGqlpType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(IGqlpEnum usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);
}
