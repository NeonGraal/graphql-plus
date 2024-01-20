using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarsAliased(
  IVerify<AstScalar> definition,
  IMerge<AstScalar> merger,
  ILoggerFactory logger
) : AliasedVerifier<AstScalar>(definition, merger, logger)
{
  public override string Label => "Scalars";
}
