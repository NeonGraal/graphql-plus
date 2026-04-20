using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyFragmentUsage(IVerifierRepository verifiers) : IdentifiedVerifier<IAstSpread, IAstFragment>(verifiers)
{
  public override string Label => "Spread";

  public override string UsageKey(IAstSpread item) => item.Identifier;

  internal static VerifyFragmentUsage Factory(IVerifierRepository v) => new(v);
}
