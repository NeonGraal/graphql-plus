using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainsAliased(
  IVerify<IGqlpDomain> definition,
  IMergerRepository mergers
) : AliasedVerifier<IGqlpDomain>(definition, mergers)
{
  public override string Label => "Domains";
}
