using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualsAliased(
  IVerify<DualDeclAst> definition,
  IMerge<DualDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DualDeclAst>(definition, merger, logger)
{
  public override string Label => "Duals";
}
