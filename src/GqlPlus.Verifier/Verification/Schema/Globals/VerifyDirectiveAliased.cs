using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyDirectiveAliased(
  IVerify<IGqlpSchemaDirective> definition,
  IMerge<IGqlpSchemaDirective> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpSchemaDirective>(definition, merger, logger)
{
  public override string Label => "Directives";
}
