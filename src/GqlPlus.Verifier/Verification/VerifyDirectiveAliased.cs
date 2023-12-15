using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyDirectiveAliased(
  IVerify<DirectiveDeclAst> definition,
  IMerge<DirectiveDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<DirectiveDeclAst>(definition, merger, logger)
{
  public override string Label => "Directives";
}
