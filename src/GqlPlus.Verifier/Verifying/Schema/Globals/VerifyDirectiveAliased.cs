using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveAliased(
  IVerify<IGqlpSchemaDirective> definition,
  IMergerRepository mergers
) : AliasedVerifier<IGqlpSchemaDirective>(definition, mergers)
{
  public override string Label => "Directives";
}
