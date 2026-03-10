using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class ObjectsAliasedVerifier<TField>(
  IVerify<IGqlpObject<TField>> definition,
  IMergerRepository mergers,
  IGqlpFieldKind<TField> fieldKind
) : AliasedVerifier<IGqlpObject<TField>>(definition, mergers)
  where TField : IGqlpObjField
{
  public override string Label { get; } = fieldKind.FieldKind.ToString() + "s";
}
