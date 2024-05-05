using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema;

internal abstract partial class GroupedVerifier<TAliased>(
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : IVerifyAliased<TAliased>
 where TAliased : IGqlpAliased
{
#pragma warning disable CA1823 // Avoid unused private fields - DO NOT DELETE
  private readonly ILogger _logger = logger.CreateLogger(nameof(GroupedVerifier<TAliased>));

  public abstract string Label { get; }

  public virtual void Verify(TAliased[] item, ITokenMessages errors)
  {
    if (item.Length == 0) {
      return;
    }

    GroupVerifying(item.GetType());

    Map<TAliased[]> byName = item.GroupBy(t => t.Name)
      .ToMap(g => g.Key, g => g.ToArray());

    VerifyAliases(item, byName.Keys, errors);

    VerifyDefinitions(byName, errors);
  }

  private void GroupVerifying(Type type)
    => GroupVerifying(type.GetElementType()?.ExpandTypeName());

  [LoggerMessage(Level = LogLevel.Information, Message = "Group verifying of {Type}")]
  private partial void GroupVerifying(string? type);

  private void VerifyDefinitions(Map<TAliased[]> byName, ITokenMessages errors)
  {
    foreach ((string name, TAliased[] definitions) in byName) {
      if (definitions.Length == 1) {
        continue;
      }

      VerifyingWithDefinitions(name, definitions.Length);

      ITokenMessages failures = merger.CanMerge(definitions);
      if (failures.Any()) {
        errors.Add(definitions.Last().MakeError($"Multiple {Label} with name '{name}' can't be merged."));
        errors.Add(failures);
      }
    }
  }

  [LoggerMessage(Level = LogLevel.Information, Message = "Verifying {Name} with {Count} definitions")]
  private partial void VerifyingWithDefinitions(string name, int count);

  private void VerifyAliases(TAliased[] item, IReadOnlyCollection<string> names, ITokenMessages errors)
  {
    IEnumerable<IGrouping<string, TAliased>> byAlias = item.SelectMany(t => t.Aliases.Select(a => (Alias: a, Item: t)))
          .Where(a => !names.Contains(a.Alias))
          .GroupBy(a => a.Alias, a => a.Item);

    foreach (IGrouping<string, TAliased> alias in byAlias) {
      string[] aliases = alias.Select(a => a.Name).Distinct().ToArray();
      if (aliases.Length > 1) {
        errors.Add(alias.Last().MakeError($"Multiple {Label} with alias '{alias.Key}' found. Names {aliases.Joined(n => $"'{n}'")}"));
      }
    }
  }
}

public interface IVerifyAliased<TAliased>
  : IVerify<TAliased[]>
    where TAliased : IGqlpAliased
{ }
