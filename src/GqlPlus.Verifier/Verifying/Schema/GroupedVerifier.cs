using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema;

internal abstract class GroupedVerifier<TAliased>(
   IMerge<TAliased> merger,
   ILoggerFactory logger
) : IVerifyAliased<TAliased>
 where TAliased : IGqlpAliased
{
  private readonly ILogger _logger = logger.CreateTypedLogger<GroupedVerifier<TAliased>>();

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
    => _logger.GroupVerifying(type.GetElementType()?.TidyTypeName());

  private void VerifyDefinitions(Map<TAliased[]> byName, ITokenMessages errors)
  {
    foreach (MapPair<TAliased[]> item in byName) {
      if (item.Value.Length == 1) {
        continue;
      }

      _logger.VerifyingWithDefinitions(item.Key, item.Value.Length);

      ITokenMessages failures = merger.CanMerge(item.Value);
      if (failures.Any()) {
        errors.Add(item.Value.Last().MakeError($"Multiple {Label} with name '{item.Key}' can't be merged."));
        errors.Add(failures);
      }
    }
  }

  private void VerifyAliases(TAliased[] item, IReadOnlyCollection<string> names, ITokenMessages errors)
  {
    IEnumerable<IGrouping<string, TAliased>> byAlias = item
      .SelectMany(ExtractAliases)
      .Where(AliasExists)
      .GroupBy(a => a.a, a => a.t);

    foreach (IGrouping<string, TAliased> alias in byAlias) {
      string[] aliases = [.. alias.Select(a => a.Name).Distinct()];
      if (aliases.Length > 1) {
        errors.Add(alias.Last().MakeError($"Multiple {Label} with alias '{alias.Key}' found. Names {aliases.Joined(n => $"'{n}'")}"));
      }
    }

    bool AliasExists((string a, TAliased) a)
      => !names.Contains(a.a);

    static IEnumerable<(string a, TAliased t)> ExtractAliases(TAliased t)
      => t.Aliases.Select(a => (a, t));
  }
}

public interface IVerifyAliased<TAliased>
  : IVerify<TAliased[]>
    where TAliased : IGqlpAliased
{ }

internal static partial class GroupedVerifierLogging
{
  [LoggerMessage(Level = LogLevel.Information, Message = "Group verifying of {Type}")]
  internal static partial void GroupVerifying(this ILogger logger, string? type);

  [LoggerMessage(Level = LogLevel.Information, Message = "Verifying {Name} with {Count} definitions")]
  internal static partial void VerifyingWithDefinitions(this ILogger logger, string name, int count);
}
