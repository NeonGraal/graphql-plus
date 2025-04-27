using System.Collections.ObjectModel;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public abstract class UsageVerifierBase<TUsage>
  : VerifierBase
  where TUsage : class, IGqlpAliased
{
  internal ForVA<TUsage> Aliased { get; } = new();
  protected Collection<TUsage> Usages { get; } = [];
  protected Collection<IGqlpType> Definitions { get; } = [];

  protected UsageAliased<TUsage> UsageAliased => new([.. Usages], [.. Definitions]);

}
