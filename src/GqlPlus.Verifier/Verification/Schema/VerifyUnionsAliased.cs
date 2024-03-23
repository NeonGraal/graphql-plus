using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyUnionsAliased(
  IVerify<UnionDeclAst> definition,
  IMerge<UnionDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<UnionDeclAst>(definition, merger, logger)
{
  public override string Label => "Unions";
}
