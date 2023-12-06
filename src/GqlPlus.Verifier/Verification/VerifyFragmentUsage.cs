using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;

internal class VerifyFragmentUsage(
    IVerify<SpreadAst> usage,
    IVerify<FragmentAst> definition
) : UsageNamedVerifier<SpreadAst, FragmentAst>(usage, definition)
{
  public override string Label => "Spread";

  public override string UsageKey(SpreadAst item) => item.Name;
}
