using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema.Simple;

internal class VerifyDomainsAliased(
  IVerify<AstDomain> definition,
  IMerge<AstDomain> merger,
  ILoggerFactory logger
) : AliasedVerifier<AstDomain>(definition, merger, logger)
{
  public override string Label => "Domains";
}
