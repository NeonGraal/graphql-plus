using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyOptionAliased(IVerifierRepository verifiers) : AliasedVerifier<IGqlpSchemaOption>(verifiers)
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
