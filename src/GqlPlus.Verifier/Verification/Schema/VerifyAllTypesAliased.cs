using GqlPlus.Ast.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema;

internal class VerifyAllTypesAliased(
  IMerge<AstType> merger,
  ILoggerFactory logger
) : GroupedVerifier<AstType>(merger, logger)
{
  public override string Label => "Types";
}
