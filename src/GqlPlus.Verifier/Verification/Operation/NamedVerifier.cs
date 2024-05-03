using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Verification.Operation;

internal abstract class NamedVerifier<TUsage, TNamed>(
    IVerify<TUsage> usage,
    IVerify<TNamed> definition
) : IVerifyNamed<TUsage, TNamed>
  where TUsage : AstAbbreviated where TNamed : AstNamed
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public void Verify(UsageNamed<TUsage, TNamed> item, ITokenMessages errors)
  {
    Dictionary<string, TUsage> used = item.Usages.ToDictionary(UsageKey);

    Dictionary<string, TNamed> defined = item.Definitions.ToDictionary(f => f.Name);

    foreach ((string k, TUsage u) in used) {
      if (!defined.ContainsKey(k)) {
        errors.AddError(u, $"Invalid {Label} usage. {Label} not defined.");
      }

      usage?.Verify(u, errors);
    }

    foreach ((string k, TNamed d) in defined) {
      if (!used.ContainsKey(k)) {
        errors.AddError(d, $"Invalid {Label} definition. {Label} not used.");
      }

      definition?.Verify(d, errors);
    }
  }
}

public record class UsageNamed<TUsage, TNamed>(TUsage[] Usages, TNamed[] Definitions)
  where TUsage : AstAbbreviated where TNamed : AstNamed;

public interface IVerifyNamed<TUsage, TNamed> : IVerify<UsageNamed<TUsage, TNamed>>
    where TUsage : AstAbbreviated where TNamed : AstNamed
{ }
