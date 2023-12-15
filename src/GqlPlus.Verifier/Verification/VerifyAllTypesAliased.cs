using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyAllTypesAliased(
  IVerify<AstType> definition,
  IMerge<AstType> merger,
  ILoggerFactory logger
) : AliasedVerifier<AstType>(definition, merger, logger)
{
  public override string Label => "Types";

  protected override object GroupKey(AstType item) => item.Name;
}
