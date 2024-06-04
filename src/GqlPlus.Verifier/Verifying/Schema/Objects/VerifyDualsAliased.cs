using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualsAliased(
  IVerify<IGqlpDualObject> definition,
  IMerge<IGqlpDualObject> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpDualObject>(definition, merger, logger)
{
  public override string Label => "Duals";
}
