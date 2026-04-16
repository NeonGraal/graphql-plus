using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypesAliased(IVerifierRepository verifiers) : GroupedVerifier<IAstType>(verifiers)
{
  public override string Label => "Types";

  internal static VerifyAllTypesAliased Factory(IVerifierRepository v) => new(v);
}
