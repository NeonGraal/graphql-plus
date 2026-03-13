using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumTypes(IVerifierRepository verifiers) : AstSimpleVerifier<IGqlpEnum, UsageContext, IGqlpEnumLabel>(verifiers)
{
  protected override IEnumerable<IGqlpEnumLabel> GetItems(IGqlpEnum usage)
    => usage.Items;

  protected override UsageContext MakeContext(IGqlpEnum usage, IGqlpType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);
}
