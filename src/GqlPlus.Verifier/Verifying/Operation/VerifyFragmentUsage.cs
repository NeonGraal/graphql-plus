using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyFragmentUsage(IVerifierRepository verifiers) : IdentifiedVerifier<IAstSpread, IAstFragment>(verifiers)
{
  public override string Label => "Spread";

  public override string UsageKey(IAstSpread item) => item.Identifier;
}
