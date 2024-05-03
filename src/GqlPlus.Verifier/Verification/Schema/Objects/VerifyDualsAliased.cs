using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Objects;

internal class VerifyDualsAliased(
  IVerify<DualDeclAst> definition,
  IMerge<DualDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DualDeclAst>(definition, merger, logger)
{
  public override string Label => "Duals";
}
