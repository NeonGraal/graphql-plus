using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryAliased(
  IVerify<IGqlpSchemaCategory> definition,
  IMerge<IGqlpSchemaCategory> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpSchemaCategory>(definition, merger, logger)
{
  public override string Label => "Categories";
}
