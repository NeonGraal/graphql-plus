namespace GqlPlus.Verifying.Operation;

internal abstract class NamedVerifier<TUsage, TNamed>(
    IVerify<TUsage> usage,
    IVerify<TNamed> definition
) : IVerifyNamed<TUsage, TNamed>
  where TUsage : IGqlpError where TNamed : IGqlpNamed
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public void Verify(UsageNamed<TUsage, TNamed> item, ITokenMessages errors)
  {
    Dictionary<string, TUsage> used = item.Usages.ToDictionary(UsageKey);

    Dictionary<string, TNamed> defined = item.Definitions.ToDictionary(f => f.Name);

    foreach (KeyValuePair<string, TUsage> use in used) {
      if (!defined.ContainsKey(use.Key)) {
        errors.Add(use.Value.MakeError($"Invalid {Label} usage. {Label} not defined."));
      }

      usage?.Verify(use.Value, errors);
    }

    foreach (var def in defined) {
      if (!used.ContainsKey(def.Key)) {
        errors.Add(def.Value.MakeError($"Invalid {Label} definition. {Label} not used."));
      }

      definition?.Verify(def.Value, errors);
    }
  }
}

public record class UsageNamed<TUsage, TNamed>(IEnumerable<TUsage> Usages, IEnumerable<TNamed> Definitions)
  where TUsage : IGqlpError where TNamed : IGqlpNamed;

public interface IVerifyNamed<TUsage, TNamed> : IVerify<UsageNamed<TUsage, TNamed>>
    where TUsage : IGqlpError where TNamed : IGqlpNamed
{ }
