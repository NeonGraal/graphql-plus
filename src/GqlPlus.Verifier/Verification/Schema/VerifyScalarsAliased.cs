using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarsAliased(
  IVerify<ScalarDeclAst> definition,
  IMerge<ScalarDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<ScalarDeclAst>(definition, merger, logger)
{
  public override string Label => "Scalars";
}
