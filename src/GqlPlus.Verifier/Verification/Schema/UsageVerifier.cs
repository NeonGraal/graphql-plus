using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Verification.Schema;

internal abstract class UsageVerifier<TUsage, TAliased, TContext>(
  IVerifyAliased<TUsage> aliased
) : IVerifyUsage<TUsage, TAliased>
 where TUsage : AstAliased where TAliased : AstAliased where TContext : UsageContext
{
  protected abstract void UsageValue(TUsage usage, TContext context);
  protected abstract TContext MakeContext(TUsage usage, TAliased[] aliased, ITokenMessages errors);

  public virtual void Verify(UsageAliased<TUsage, TAliased> item, ITokenMessages errors)
  {
    foreach (TUsage usage in item.Usages) {
      TContext context = MakeContext(usage, item.Definitions, errors);
      UsageValue(usage, context);
    }

    aliased.Verify(item.Usages, errors);
  }

  protected static UsageContext MakeUsageContext(TAliased[] aliased, ITokenMessages errors)
    => new(
      aliased.AliasedMap(p => (AstDescribed)p.First())
      , errors);
}

public record class UsageAliased<TUsage, TAliased>(TUsage[] Usages, TAliased[] Definitions)
  where TUsage : AstAbbreviated where TAliased : AstAliased;

public interface IVerifyUsage<TUsage, TAliased> : IVerify<UsageAliased<TUsage, TAliased>>
    where TUsage : AstAbbreviated where TAliased : AstAliased
{ }
