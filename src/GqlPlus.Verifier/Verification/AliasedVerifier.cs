using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class AliasedVerifier<TAliased>(
   IVerify<TAliased> definition
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  public abstract string Label { get; }

  public ITokenMessages Verify(TAliased[] target)
  {
    var errors = new TokenMessages();

    var names = target.Select(d => d.Name).Distinct().ToHashSet();

    var byName = target.GroupBy(t => t.Name)
      .ToDictionary(g => g.Key, g => g.ToArray());

    var byAlias = target.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .GroupBy(p => p.Id, p => p.Item)
      .ToDictionary(g => g.Key, g => g.ToList());

    foreach (var (alias, definitions) in byAlias) {
      var set = definitions.GroupBy(GroupKey);
      if (set.Count() > 1) {
        errors.Add(definitions.Last().Error($"Invalid {Label}. Multiple {Label} with alias '{alias}' found."));
        continue;
      }
    }

    foreach (var (name, definitions) in byName) {
      var set = definitions.GroupBy(GroupKey);
      if (set.Count() > 1) {
        errors.Add(definitions.Last().Error($"Invalid {Label}. Multiple {Label} named '{name}' found."));
        continue;
      }

      if (definition is not null) {
        errors.AddRange(definition.Verify(definitions.First()));
      }
    }

    return (ITokenMessages)errors;
  }

  protected abstract object GroupKey(TAliased aliased);
}

public interface IVerifyAliased<TAliased> : IVerify<TAliased[]>
    where TAliased : AstAliased
{ }
