using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputsAliased(
  IVerify<OutputDeclAst> definition,
  IMerge<OutputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<OutputDeclAst>(definition, merger, logger)
{
  public override string Label => "Outputs";
}
