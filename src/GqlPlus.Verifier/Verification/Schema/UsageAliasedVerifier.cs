using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class UsageAliasedVerifier<TUsage, TAliased, TContext>(
  IVerifyAliased<TUsage> aliased
) : IVerifyUsageAliased<TUsage, TAliased>
 where TUsage : AstAliased where TAliased : AstAliased where TContext : UsageContext
{
  protected abstract void UsageValue(TUsage usage, TContext context);
  protected abstract TContext MakeContext(TUsage usage, IMap<TAliased[]> byId, ITokenMessages errors);

  public virtual void Verify(UsageAliases<TUsage, TAliased> item, ITokenMessages errors)
  {
    var byId = item.Definitions.AliasedMap();

    foreach (var usage in item.Usages) {
      var context = MakeContext(usage, byId, errors);
      UsageValue(usage, context);
    }

    aliased.Verify(item.Usages, errors);
  }

  protected static UsageContext MakeUsageContext(IMap<TAliased[]> byId, ITokenMessages errors)
    => new(
      byId.ToMap(
        p => p.Key,
        p => (AstDescribed)p.Value.First())
      , errors);
}

public record class UsageAliases<TUsage, TAliased>(TUsage[] Usages, TAliased[] Definitions)
  where TUsage : AstBase where TAliased : AstAliased;

public interface IVerifyUsageAliased<TUsage, TAliased> : IVerify<UsageAliases<TUsage, TAliased>>
    where TUsage : AstBase where TAliased : AstAliased
{ }

internal record class UsageContext(IMap<AstDescribed> Types, ITokenMessages Errors)
{
  public readonly HashSet<string> Used = [];

  public void AddError<TAst>(TAst item, string message)
      where TAst : AstBase
      => Errors.AddError(item, message);

  public bool GetType(string type, out AstDescribed? value)
  {
    if (Types.TryGetValue(type, out value)) {
      Used.Add(type);
      return true;
    }

    value = default;
    return false;
  }
}
