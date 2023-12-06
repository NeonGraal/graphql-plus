using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal abstract class UsageNamedVerifier<TUsage, TNamed>(
    IVerify<TUsage> usage,
    IVerify<TNamed> definition
) : IVerifyUsageNamed<TUsage, TNamed>
  where TUsage : AstBase where TNamed : AstNamed
{
  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);

  public ITokenMessages Verify(UsageNames<TUsage, TNamed> target)
  {
    var errors = new TokenMessages();

    var used = target.Usages.ToDictionary(UsageKey);

    var defined = target.Definitions.ToDictionary(f => f.Name);

    foreach (var (k, u) in used) {
      if (!defined.ContainsKey(k)) {
        errors.Add(u.Error($"Invalid {Label} usage. {Label} not defined."));
      }

      if (usage is not null) {
        errors.AddRange(usage.Verify(u));
      }
    }

    foreach (var (k, d) in defined) {
      if (!used.ContainsKey(k)) {
        errors.Add(d.Error($"Invalid {Label} definition. {Label} not used."));
      }

      if (definition is not null) {
        errors.AddRange(definition.Verify(d));
      }
    }

    return errors;
  }
}

public record class UsageNames<TUsage, TNamed>(TUsage[] Usages, TNamed[] Definitions)
  where TUsage : AstBase where TNamed : AstNamed;

public interface IVerifyUsageNamed<TUsage, TNamed> : IVerify<UsageNames<TUsage, TNamed>>
    where TUsage : AstBase where TNamed : AstNamed
{ }
