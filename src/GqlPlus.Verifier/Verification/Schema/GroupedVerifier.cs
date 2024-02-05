using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;
using YamlDotNet.Core.Tokens;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class GroupedVerifier<TAliased>(
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : IVerifyAliased<TAliased>
 where TAliased : AstAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(GroupedVerifier<TAliased>));

  public abstract string Label { get; }

  public virtual void Verify(TAliased[] item, ITokenMessages errors)
  {
    if (item.Length == 0) {
      return;
    }

    _logger.LogInformation("Group verifying of {Type}", item.GetType().GetElementType()?.ExpandTypeName());

    var byName = item.GroupBy(t => t.Name)
      .ToMap(g => g.Key, g => g.ToArray());

    VerifyAliases(item, byName.Keys, errors);

    VerifyDefinitions(byName, errors);
  }

  private void VerifyDefinitions(Map<TAliased[]> byName, ITokenMessages errors)
  {
    foreach (var (name, definitions) in byName) {
      if (definitions.Length == 1) {
        continue;
      }

      _logger.LogInformation("Verifying {Name} with {Count} definitions", name, definitions.Length);

      if (!merger.CanMerge(definitions)) {
        errors.Add(definitions.Last().Error($"Multiple {Label} with name '{name}' can't be merged."));
      }
    }
  }

  private void VerifyAliases(TAliased[] item, IReadOnlyCollection<string> names, ITokenMessages errors)
  {
    var byAlias = item.SelectMany(t => t.Aliases.Select(a => (Alias: a, Item: t)))
          .Where(a => !names.Contains(a.Alias))
          .GroupBy(a => a.Alias, a => a.Item);

    foreach (var alias in byAlias) {
      var aliases = alias.Select(a => a.Name).Distinct().ToArray();
      if (aliases.Length > 1) {
        errors.Add(alias.Last().Error($"Multiple {Label} with alias '{alias.Key}' found. Names {aliases.Joined(n => $"'{n}'")}"));
      }
    }
  }
}

public interface IVerifyAliased<TAliased> : IVerify<TAliased[]>
    where TAliased : AstAliased
{ }
