using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyDomainsAliased(
  IVerify<IGqlpDomain> definition,
  IMerge<IGqlpDomain> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpDomain>(definition, merger, logger)
{
  public override string Label => "Domains";
}
