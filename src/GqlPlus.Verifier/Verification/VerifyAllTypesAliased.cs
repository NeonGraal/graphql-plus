using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyAllTypesAliased(
  IMerge<AstType> merger,
  ILoggerFactory logger
) : GroupedVerifier<AstType>(merger, logger)
{
  public override string Label => "Types";
}
