namespace GqlPlus.Verifying.Operation;

internal abstract class NamedVerifier<TUsage, TNamed>(
    IVerify<TUsage> usage,
    IVerify<TNamed> definition
) : IVerifyNamed<TUsage, TNamed>
  where TUsage : IGqlpError
  where TNamed : IGqlpNamed
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public void Verify(UsageNamed<TUsage, TNamed> item, ITokenMessages errors)
  {
    Dictionary<string, TUsage> used = item.Usages.ToDictionary(UsageKey);

    Dictionary<string, TNamed> defined = item.Definitions.ToDictionary(f => f.Name);

    foreach ((string k, TUsage u) in used) {
      if (!defined.ContainsKey(k)) {
        errors.Add(u.MakeError($"Invalid {Label} usage. {Label} not defined."));
      }

      usage?.Verify(u, errors);
    }

    foreach ((string k, TNamed d) in defined) {
      if (!used.ContainsKey(k)) {
        errors.Add(d.MakeError($"Invalid {Label} definition. {Label} not used."));
      }

      definition?.Verify(d, errors);
    }
  }
}

public record class UsageNamed<TUsage, TNamed>(IEnumerable<TUsage> Usages, IEnumerable<TNamed> Definitions)
  where TUsage : IGqlpError where TNamed : IGqlpNamed;

public interface IVerifyNamed<TUsage, TNamed> : IVerify<UsageNamed<TUsage, TNamed>>
    where TUsage : IGqlpError where TNamed : IGqlpNamed
{ }
