using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyEnumsAliased(
  IVerify<IGqlpEnum> definition,
  IMerge<IGqlpEnum> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpEnum>(definition, merger, logger)
{
  public override string Label => "Enums";
}
