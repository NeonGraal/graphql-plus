using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyOptionAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstSchemaOption>(verifiers)
{
  public override string Label => "Options";

  public override void Verify(IAstSchemaOption[] item, IMessages errors)
  {
    if (item.Select(i => i.Name).Distinct().Count() > 1) {
      errors.Add(item.Last().MakeError($"Multiple Schema names ({Label}) found."));
    }

    base.Verify(item, errors);
  }

  internal static VerifyOptionAliased Factory(IVerifierRepository v) => new(v);
}
