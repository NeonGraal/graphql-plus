using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;

internal class VerifyFragmentUsage : UsageVerifier<SpreadAst, FragmentAst>
{
  public override string Label => "Spread";

  public override string UsageKey(SpreadAst item) => item.Name;

  public override bool Verify<TContext>(TContext context, SpreadAst[] target)
  {
    if (context is FragmentsContext fragments) {
      VerifyUsages(target, fragments.Fragments, context);
    }

    return true;
  }

  protected override void VerifyDefinition(FragmentAst d, VerificationContext context) { }
  protected override void VerifyUsage(SpreadAst u, VerificationContext context) { }
}
