using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Objects;

internal class ObjectsAliasedVerifier<TField>(
  IVerify<IGqlpObject<TField>> definition,
  IMerge<IGqlpObject<TField>> merger,
  ILoggerFactory logger,
  IGqlpFieldKind<TField> fieldKind
) : AliasedVerifier<IGqlpObject<TField>>(definition, merger, logger)
  where TField : IGqlpObjField
{
  public override string Label { get; } = fieldKind.FieldKind.ToString() + "s";
}
