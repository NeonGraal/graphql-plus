using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyDualsAliased(
  IVerify<DualDeclAst> definition,
  IMerge<DualDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DualDeclAst>(definition, merger, logger)
{
  public override string Label => "Duals";
}
