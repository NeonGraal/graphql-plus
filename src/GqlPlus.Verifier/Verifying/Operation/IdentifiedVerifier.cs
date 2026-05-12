using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal abstract class IdentifiedVerifierBase<TUsage, TIdentified>(
    IVerifierRepository verifiers
) : IVerifyIdentified<TUsage, TIdentified>
  where TUsage : IAstError
  where TIdentified : IAstIdentified
{
  private readonly Verifier<TUsage> _usage = verifiers.VerifierFor<TUsage>();
  private readonly Verifier<TIdentified> _definition = verifiers.VerifierFor<TIdentified>();

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

      _usage.Verify(use.Value, errors);
    }

    foreach (MapPair<TIdentified> def in defined) {
      if (!used.ContainsKey(def.Key)) {
        errors.Add(def.Value.MakeError($"Invalid {Label} definition. {Label} not used."));
      }

      _definition.Verify(def.Value, errors);
    }
  }
}

public record class UsageIdentified<TUsage, TIdentified>(IEnumerable<TUsage> Usages, IEnumerable<TIdentified> Definitions)
  where TUsage : IAstError where TIdentified : IAstIdentified;

public interface IVerifyIdentified<TUsage, TIdentified> : IVerify<UsageIdentified<TUsage, TIdentified>>
    where TUsage : IAstError where TIdentified : IAstIdentified
{ }

public class IdentifiedVerifier<TUsage, TIdentified>(
  IdentifiedVerifier<TUsage, TIdentified>.D factory
) : DeferOne<IVerifyIdentified<TUsage, TIdentified>>(factory)
  , IVerifyIdentified<TUsage, TIdentified>
  where TUsage : IAstError
  where TIdentified : IAstIdentified
{
  public void Verify(UsageIdentified<TUsage, TIdentified> item, IMessages errors)
    => Value.Verify(item, errors);

  public static implicit operator IdentifiedVerifier<TUsage, TIdentified>(D factory)
    => new(factory.ThrowIfNull());
}
