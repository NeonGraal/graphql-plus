using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyDirectiveAliased(
  IVerify<DirectiveDeclAst> definition,
  IMerge<DirectiveDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DirectiveDeclAst>(definition, merger, logger)
{
  public override string Label => "Directives";
}
