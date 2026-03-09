using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class ObjectsAliasedVerifier<TField>(IVerifierRepository verifiers) : AliasedVerifier<IGqlpObject<TField>>(verifiers)
  where TField : IGqlpObjField
{
  public override string Label { get; } = verifiers.FieldKindFor<TField>().FieldKind.ToString() + "s";
}
