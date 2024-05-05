using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyOptionAliased(
  IVerify<IGqlpSchemaOption> definition,
  IMerge<IGqlpSchemaOption> merger,
  ILoggerFactory logger
) : AliasedVerifier<IGqlpSchemaOption>(definition, merger, logger)
{
  public override string Label => "Options";

  public override void Verify(IGqlpSchemaOption[] item, ITokenMessages errors)
  {
    if (item.Select(i => i.Name).Distinct().Count() > 1) {
      errors.Add(item.Last().MakeError($"Multiple Schema names ({Label}) found."));
    }

    base.Verify(item, errors);
  }
}
