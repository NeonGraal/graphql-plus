using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumsAliased(
  IVerify<IGqlpEnum> definition,
  IMerge<IGqlpEnum> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpEnum>(definition, merger, logger)
{
  public override string Label => "Enums";
}
