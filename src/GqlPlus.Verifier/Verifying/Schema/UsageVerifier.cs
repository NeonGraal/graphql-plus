using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

internal abstract class UsageVerifier<TUsage, TContext>(
  IVerifyAliased<TUsage> aliased
) : IVerifyUsage<TUsage>
  where TUsage : IGqlpAliased
  where TContext : UsageContext
{
  protected abstract void UsageValue(TUsage usage, TContext context);
  protected abstract TContext MakeContext(TUsage usage, IGqlpType[] aliased, ITokenMessages errors);

  public virtual void Verify(UsageAliased<TUsage> item, ITokenMessages errors)
  {
    foreach (TUsage usage in item.Usages) {
      TContext context = MakeContext(usage, item.Definitions, errors);
      UsageValue(usage, context);
    }

    aliased.Verify(item.Usages, errors);
  }

  protected static UsageContext MakeUsageContext(IGqlpType[] aliased, ITokenMessages errors)
    => new(
      aliased.AliasedMap(p => (IGqlpDescribed)p.First())
      , errors);
}

public record class UsageAliased<TUsage>(
  TUsage[] Usages,
  IGqlpType[] Definitions
)
  where TUsage : IGqlpError;

public interface IVerifyUsage<TUsage>
  : IVerify<UsageAliased<TUsage>>
  where TUsage : IGqlpError
{ }
