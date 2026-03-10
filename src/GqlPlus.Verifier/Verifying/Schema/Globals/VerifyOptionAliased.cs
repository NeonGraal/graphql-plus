using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyOptionAliased(
  IVerify<IGqlpSchemaOption> definition,
  IMergerRepository mergers
) : AliasedVerifier<IGqlpSchemaOption>(definition, mergers)
{
  public override string Label => "Options";

  public override void Verify(IGqlpSchemaOption[] item, IMessages errors)
  {
    if (item.Select(i => i.Name).Distinct().Count() > 1) {
      errors.Add(item.Last().MakeError($"Multiple Schema names ({Label}) found."));
    }

    base.Verify(item, errors);
  }
}
