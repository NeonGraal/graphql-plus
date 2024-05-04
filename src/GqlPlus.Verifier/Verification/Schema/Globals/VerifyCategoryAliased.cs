using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyCategoryAliased(
  IVerify<IGqlpSchemaCategory> definition,
  IMerge<IGqlpSchemaCategory> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpSchemaCategory>(definition, merger, logger)
{
  public override string Label => "Categories";
}
