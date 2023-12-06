using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class UsageAliasedVerifier<TUsage, TAliased>
  : IVerifyUsageAliased<TUsage, TAliased>
 where TUsage : AstBase where TAliased : AstAliased
{
  protected abstract string Label { get; }
  protected abstract string UsageKey(TUsage item);
  protected abstract ITokenMessages UsageValue(TUsage usage, IMap<TAliased[]> byId);

  public ITokenMessages Verify(UsageAliases<TUsage, TAliased> target)
  {
    var errors = new TokenMessages();

    var used = target.Usages.GroupBy(UsageKey)
      .ToDictionary(g => g.Key, g => g.ToArray());

    var names = target.Definitions.Select(d => d.Name).Distinct().ToHashSet();

    var byName = target.Definitions.GroupBy(t => t.Name);

    var byId = target.Definitions.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .GroupBy(p => p.Id, p => p.Item)
      .Union(byName)
      .ToMap(g => g.Key, g => g.ToArray());

    foreach (var usage in target.Usages) {
      errors.AddRange(UsageValue(usage, byId));
      //if (!byId.ContainsKey(k)) {
      //  errors.Add(u.First().Error($"Invalid {Label} usage. {Label} not defined."));
      //}
    }

    return (ITokenMessages)errors;
  }
}

public record class UsageAliases<TUsage, TAliased>(TUsage[] Usages, TAliased[] Definitions)
  where TUsage : AstBase where TAliased : AstAliased;

public interface IVerifyUsageAliased<TUsage, TAliased> : IVerify<UsageAliases<TUsage, TAliased>>
    where TUsage : AstBase where TAliased : AstAliased
{ }
