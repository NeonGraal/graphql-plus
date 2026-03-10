using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumsAliased(
  IVerify<IGqlpEnum> definition,
  IMergerRepository mergers
) : AliasedVerifier<IGqlpEnum>(definition, mergers)
{
  public override string Label => "Enums";
}
