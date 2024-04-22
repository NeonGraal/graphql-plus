using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Globals;

internal class VerifyDirectiveAliased(
  IVerify<DirectiveDeclAst> definition,
  IMerge<DirectiveDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DirectiveDeclAst>(definition, merger, logger)
{
  public override string Label => "Directives";
}
