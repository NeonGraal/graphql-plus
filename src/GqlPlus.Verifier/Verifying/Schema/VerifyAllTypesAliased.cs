using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypesAliased(
  IMerge<IGqlpType> merger,
  ILoggerFactory logger
) : GroupedVerifier<IGqlpType>(merger, logger)
{
  public override string Label => "Types";
}
