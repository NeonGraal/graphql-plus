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
    Dictionary<string, TUsage> used = item.Usages.ToDictionary(UsageKey);

    Dictionary<string, TIdentified> defined = item.Definitions.ToDictionary(f => f.Identifier);

    foreach (MapPair<TUsage> use in used) {
      if (!defined.ContainsKey(use.Key)) {
        errors.Add(use.Value.MakeError($"Invalid {Label} usage. {Label} not defined."));
      }

      _usage?.Verify(use.Value, errors);
    }

    foreach (MapPair<TIdentified> def in defined) {
      if (!used.ContainsKey(def.Key)) {
        errors.Add(def.Value.MakeError($"Invalid {Label} definition. {Label} not used."));
      }

      _definition?.Verify(def.Value, errors);
    }
  }
}

public record class UsageIdentified<TUsage, TIdentified>(IEnumerable<TUsage> Usages, IEnumerable<TIdentified> Definitions)
  where TUsage : IAstError where TIdentified : IAstIdentified;

public interface IVerifyIdentified<TUsage, TIdentified> : IVerify<UsageIdentified<TUsage, TIdentified>>
    where TUsage : IAstError where TIdentified : IAstIdentified
{ }
