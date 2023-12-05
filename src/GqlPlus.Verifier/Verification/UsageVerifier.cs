using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Verification;

internal abstract class UsageVerifier<TUsage, TDefinition> : IVerify<TUsage[]>
  where TUsage : AstBase where TDefinition : AstNamed
{
  public abstract bool Verify<TContext>(TContext context, TUsage[] target) where TContext : VerificationContext;

  protected void VerifyUsages(
    TUsage[] usages,
    TDefinition[] definitions,
    VerificationContext context
  )
  {
    var used = usages.ToDictionary(UsageKey);

    var defined = definitions.ToDictionary(f => f.Name);

    foreach (var (k, u) in used) {
      if (!defined.ContainsKey(k)) {
        context.Error(u, $"Invalid {Label} usage. {Label} not defined.");
      }

      VerifyUsage(u, context);
    }

    foreach (var (k, d) in defined) {
      if (!used.ContainsKey(k)) {
        context.Error(d, $"Invalid {Label} definition. {Label} not used.");
      }

      VerifyDefinition(d, context);
    }
  }

  public abstract string Label { get; }
  public abstract string UsageKey(TUsage item);
  protected abstract void VerifyDefinition(TDefinition d, VerificationContext context);
  protected abstract void VerifyUsage(TUsage u, VerificationContext context);
}
