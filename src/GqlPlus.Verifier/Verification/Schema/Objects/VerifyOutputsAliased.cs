using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Objects;

internal class VerifyOutputsAliased(
  IVerify<OutputDeclAst> definition,
  IMerge<OutputDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<OutputDeclAst>(definition, merger, logger)
{
  public override string Label => "Outputs";
}
