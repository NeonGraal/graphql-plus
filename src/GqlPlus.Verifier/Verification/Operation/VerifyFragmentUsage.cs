using GqlPlus.Ast.Operation;

namespace GqlPlus.Verification.Operation;

internal class VerifyFragmentUsage(
    IVerify<SpreadAst> usage,
    IVerify<FragmentAst> definition
) : NamedVerifier<SpreadAst, FragmentAst>(usage, definition)
{
  public override string Label => "Spread";

  public override string UsageKey(SpreadAst item) => item.Name;
}
