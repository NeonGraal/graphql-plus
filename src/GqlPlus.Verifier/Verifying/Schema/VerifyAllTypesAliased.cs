using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypesAliased(
  IMergerRepository mergers
) : GroupedVerifier<IGqlpType>(mergers)
{
  public override string Label => "Types";
}
