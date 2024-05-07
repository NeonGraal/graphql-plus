using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainsAliased(
  IVerify<IGqlpDomain> definition,
  IMerge<IGqlpDomain> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpDomain>(definition, merger, logger)
{
  public override string Label => "Domains";
}
