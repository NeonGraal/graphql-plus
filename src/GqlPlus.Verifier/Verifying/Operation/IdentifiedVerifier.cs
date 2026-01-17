using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal abstract class IdentifiedVerifier<TUsage, TIdentified>(
    IVerify<TUsage> usage,
    IVerify<TIdentified> definition
) : IVerifyIdentified<TUsage, TIdentified>
  where TUsage : IGqlpError
  where TIdentified : IGqlpIdentified
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public void Verify(UsageIdentified<TUsage, TIdentified> item, IMessages errors)
  {
    Map<TUsage[]> used = item.Usages.GroupBy(UsageKey).ToMap(g => g.Key, g => g.ToArray());

    Map<TIdentified> defined = item.Definitions.ToMap(f => f.Identifier);

    foreach (MapPair<TUsage[]> use in used) {
      CheckContained(defined, use.Key, use.Value[0], errors, "usage", "defined");
      foreach (TUsage value in use.Value) {
        usage?.Verify(value, errors);
      }
    }

    foreach (MapPair<TIdentified> def in defined) {
      CheckContained(used, def.Key, def.Value, errors, "definition", "used");
      definition?.Verify(def.Value, errors);
    }

    VerifyDefinitions(defined, errors);
  }

  private void CheckContained<T>(Map<T> map, string key, IGqlpError value, IMessages errors, string error1, string error2)
  {
    if (!map.ContainsKey(key)) {
      errors.Add(value.MakeError($"Invalid {Label} {error1}. {key} not {error2}."));
    }
  }

  protected virtual void VerifyDefinitions(Map<TIdentified> defined, IMessages errors)
  { }
}

public record class UsageIdentified<TUsage, TIdentified>(IEnumerable<TUsage> Usages, IEnumerable<TIdentified> Definitions)
  where TUsage : IGqlpError where TIdentified : IGqlpIdentified;

public interface IVerifyIdentified<TUsage, TIdentified> : IVerify<UsageIdentified<TUsage, TIdentified>>
    where TUsage : IGqlpError where TIdentified : IGqlpIdentified
{ }
