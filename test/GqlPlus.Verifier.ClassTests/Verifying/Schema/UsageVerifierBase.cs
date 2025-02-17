using System.Collections.ObjectModel;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

public abstract class UsageVerifierBase<TUsage>
  : VerifierBase
  where TUsage : IGqlpAliased
{
  protected IVerifyAliased<TUsage> Aliased { get; } = For<IVerifyAliased<TUsage>>();
  protected Collection<TUsage> Usages { get; } = [];
  protected Collection<IGqlpType> Definitions { get; } = [];

  protected UsageAliased<TUsage> UsageAliased => new([.. Usages], [.. Definitions]);

}
