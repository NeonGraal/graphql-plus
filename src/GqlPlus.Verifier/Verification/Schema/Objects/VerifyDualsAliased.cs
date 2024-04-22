using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Objects;

internal class VerifyDualsAliased(
  IVerify<DualDeclAst> definition,
  IMerge<DualDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DualDeclAst>(definition, merger, logger)
{
  public override string Label => "Duals";
}
