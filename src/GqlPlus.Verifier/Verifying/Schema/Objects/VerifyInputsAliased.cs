using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputsAliased(
  IVerify<IGqlpInputObject> definition,
  IMerge<IGqlpInputObject> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpInputObject>(definition, merger, logger)
{
  public override string Label => "Inputs";
}
