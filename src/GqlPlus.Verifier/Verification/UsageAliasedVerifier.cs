using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class UsageAliasedVerifier<TUsage, TAliased>(
  IVerifyAliased<TUsage> aliased
) : IVerifyUsageAliased<TUsage, TAliased>
 where TUsage : AstAliased where TAliased : AstAliased
{
  protected abstract ITokenMessages UsageValue(TUsage usage, IMap<TAliased[]> byId);

  public ITokenMessages Verify(UsageAliases<TUsage, TAliased> target)
  {
    var errors = new TokenMessages();

    errors.AddRange(aliased.Verify(target.Usages));

    var byId = target.Definitions.AliasedMap();

    foreach (var usage in target.Usages) {
      errors.AddRange(UsageValue(usage, byId));
      //if (!byId.ContainsKey(k)) {
      //  errors.Add(u.First().Error($"Invalid {Label} usage. {Label} not defined."));
      //}
    }

    return errors;
  }
}

public record class UsageAliases<TUsage, TAliased>(TUsage[] Usages, TAliased[] Definitions)
  where TUsage : AstBase where TAliased : AstAliased;

public interface IVerifyUsageAliased<TUsage, TAliased> : IVerify<UsageAliases<TUsage, TAliased>>
    where TUsage : AstBase where TAliased : AstAliased
{ }
