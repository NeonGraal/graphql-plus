using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveAliased(IVerifierRepository verifiers) : AliasedVerifier<IGqlpSchemaDirective>(verifiers)
{
  public override string Label => "Directives";
}
