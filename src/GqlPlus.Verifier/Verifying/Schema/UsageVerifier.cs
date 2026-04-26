using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal abstract class UsageVerifier<TUsage, TContext>(
  IVerifierRepository verifiers
) : IVerifyUsage<TUsage>
  where TUsage : IAstAliased
  where TContext : UsageContext
{
  private readonly IVerifyAliased<TUsage> _aliased = verifiers.AliasedFor<TUsage>();

  protected abstract void UsageValue(TUsage usage, TContext context);
  protected abstract TContext MakeContext(TUsage usage, IAstType[] aliased, IMessages errors);

  public virtual void Verify(UsageAliased<TUsage> item, IMessages errors)
  {
    foreach (TUsage usage in item.Usages) {
      TContext context = MakeContext(usage, item.Definitions, errors);
      UsageValue(usage, context);
    }

    _aliased.Verify(item.Usages, errors);
  }

  protected static UsageContext MakeUsageContext(IAstType[] aliased, IMessages errors)
    => new(
      aliased.AliasedMap(p => (IAstDescribed)p.First())
      , errors);
}

public record class UsageAliased<TUsage>(
  TUsage[] Usages,
  IAstType[] Definitions
)
  where TUsage : IAstError;

public interface IVerifyUsage<TUsage>
  : IVerify<UsageAliased<TUsage>>
  where TUsage : IAstError
{ }
