using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionsAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstUnion>(verifiers)
{
  public override string Label => "Unions";

  internal static VerifyUnionsAliased Factory(IVerifierRepository v) => new(v);
}
