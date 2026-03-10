using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionsAliased(
  IVerify<IGqlpUnion> definition,
  IMergerRepository mergers
) : AliasedVerifier<IGqlpUnion>(definition, mergers)
{
  public override string Label => "Unions";
}
