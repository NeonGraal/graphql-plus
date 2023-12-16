using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Operation;

internal abstract class UsageNamedVerifier<TUsage, TNamed>(
    IVerify<TUsage> usage,
    IVerify<TNamed> definition
) : IVerifyUsageNamed<TUsage, TNamed>
  where TUsage : AstBase where TNamed : AstNamed
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public void Verify(UsageNames<TUsage, TNamed> item, ITokenMessages errors)
  {
    var used = item.Usages.ToDictionary(UsageKey);

    var defined = item.Definitions.ToDictionary(f => f.Name);

    foreach (var (k, u) in used) {
      if (!defined.ContainsKey(k)) {
        errors.AddError(u, $"Invalid {Label} usage. {Label} not defined.");
      }

      usage?.Verify(u, errors);
    }

    foreach (var (k, d) in defined) {
      if (!used.ContainsKey(k)) {
        errors.AddError(d, $"Invalid {Label} definition. {Label} not used.");
      }

      definition?.Verify(d, errors);
    }
  }
}

public record class UsageNames<TUsage, TNamed>(TUsage[] Usages, TNamed[] Definitions)
  where TUsage : AstBase where TNamed : AstNamed;

public interface IVerifyUsageNamed<TUsage, TNamed> : IVerify<UsageNames<TUsage, TNamed>>
    where TUsage : AstBase where TNamed : AstNamed
{ }
