using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyDomainsAliased(
  IVerify<AstDomain> definition,
  IMerge<AstDomain> merger,
  ILoggerFactory logger
) : AliasedVerifier<AstDomain>(definition, merger, logger)
{
  public override string Label => "Domains";
}
