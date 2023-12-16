using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class UsageAliasedVerifier<TUsage, TAliased>(
  IVerifyAliased<TUsage> aliased
) : IVerifyUsageAliased<TUsage, TAliased>
 where TUsage : AstAliased where TAliased : AstAliased
{
  protected abstract void UsageValue(TUsage usage, IMap<TAliased[]> byId, ITokenMessages errors);

  public virtual void Verify(UsageAliases<TUsage, TAliased> item, ITokenMessages errors)
  {
    aliased.Verify(item.Usages, errors);

    var byId = item.Definitions.AliasedMap();

    foreach (var usage in item.Usages) {
      UsageValue(usage, byId, errors);
    }
  }
}

public record class UsageAliases<TUsage, TAliased>(TUsage[] Usages, TAliased[] Definitions)
  where TUsage : AstBase where TAliased : AstAliased;

public interface IVerifyUsageAliased<TUsage, TAliased> : IVerify<UsageAliases<TUsage, TAliased>>
    where TUsage : AstBase where TAliased : AstAliased
{ }
