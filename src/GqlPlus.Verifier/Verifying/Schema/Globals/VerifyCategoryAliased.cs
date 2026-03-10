using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryAliased(IVerifierRepository verifiers) : AliasedVerifier<IGqlpSchemaCategory>(verifiers)
{
  public override string Label => "Categories";
}
