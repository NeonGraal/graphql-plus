using GqlPlus.Ast;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal abstract class IdentifiedVerifier<TUsage, TIdentified>(
    IVerifierRepository verifiers
) : IVerifyIdentified<TUsage, TIdentified>
  where TUsage : IAstError
  where TIdentified : IAstIdentified
{
  private readonly IVerify<TUsage> _usage = verifiers.VerifierFor<TUsage>();
  private readonly IVerify<TIdentified> _definition = verifiers.VerifierFor<TIdentified>();

  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public void Verify(UsageIdentified<TUsage, TIdentified> item, IMessages errors)
  {
    Map<TUsage[]> used = item.Usages.GroupBy(UsageKey).ToMap(g => g.Key, g => g.ToArray());

    Map<TIdentified> defined = item.Definitions.ToMap(f => f.Identifier);

    foreach (MapPair<TUsage[]> use in used) {
      CheckUse(errors, defined, use);
    }

    foreach (MapPair<TIdentified> def in defined) {
      CheckDefinition(errors, used, def);
    }

    VerifyDefinitions(defined, errors);
  }

  private void CheckDefinition(IMessages errors, Map<TUsage[]> used, MapPair<TIdentified> def)
  {
    CheckContained(used, def.Key, def.Value, errors, "definition", "used");
    _definition?.Verify(def.Value, errors);
  }

  private void CheckUse(IMessages errors, Map<TIdentified> defined, MapPair<TUsage[]> use)
  {
    CheckContained(defined, use.Key, use.Value[0], errors, "usage", "defined");
    foreach (TUsage value in use.Value) {
      _usage?.Verify(value, errors);
    }
  }

  private void CheckContained<T>(Map<T> map, string key, IAstError value, IMessages errors, string error1, string error2)
  {
    if (!map.ContainsKey(key)) {
      errors.Add(value.MakeError($"Invalid {Label} {error1}. '{key}' not {error2}."));
    }
  }

  protected virtual void VerifyDefinitions(Map<TIdentified> defined, IMessages errors)
  { }
}

public record class UsageIdentified<TUsage, TIdentified>(IEnumerable<TUsage> Usages, IEnumerable<TIdentified> Definitions)
  where TUsage : IAstError where TIdentified : IAstIdentified;

public interface IVerifyIdentified<TUsage, TIdentified> : IVerify<UsageIdentified<TUsage, TIdentified>>
    where TUsage : IAstError where TIdentified : IAstIdentified
{ }
