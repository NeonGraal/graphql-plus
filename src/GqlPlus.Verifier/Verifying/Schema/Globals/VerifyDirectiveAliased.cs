using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstSchemaDirective>(verifiers)
{
  public override string Label => "Directives";

  internal static VerifyDirectiveAliased Factory(IVerifierRepository v) => new(v);
}
