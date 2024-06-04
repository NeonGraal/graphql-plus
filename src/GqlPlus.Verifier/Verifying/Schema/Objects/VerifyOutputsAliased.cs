using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputsAliased(
  IVerify<IGqlpOutputObject> definition,
  IMerge<IGqlpOutputObject> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpOutputObject>(definition, merger, logger)
{
  public override string Label => "Outputs";
}
