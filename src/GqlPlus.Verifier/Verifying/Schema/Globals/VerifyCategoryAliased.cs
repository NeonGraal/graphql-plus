using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryAliased(
  IVerify<IGqlpSchemaCategory> definition,
  IMergerRepository mergers
) : AliasedVerifier<IGqlpSchemaCategory>(definition, mergers)
{
  public override string Label => "Categories";
}
