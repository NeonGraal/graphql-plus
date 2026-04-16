using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstSchemaCategory>(verifiers)
{
  public override string Label => "Categories";

  internal static VerifyCategoryAliased Factory(IVerifierRepository v) => new(v);
}
