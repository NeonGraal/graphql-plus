using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionsAliased(
  IVerify<IGqlpUnion> definition,
  IMerge<IGqlpUnion> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpUnion>(definition, merger, logger)
{
  public override string Label => "Unions";
}
