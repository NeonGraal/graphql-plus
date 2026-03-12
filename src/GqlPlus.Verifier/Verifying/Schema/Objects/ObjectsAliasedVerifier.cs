using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class ObjectsAliasedVerifier<TField>(IVerifierRepository verifiers, TypeKind fieldKind)
  : AliasedVerifier<IGqlpObject<TField>>(verifiers)
  where TField : IGqlpObjField
{
  public override string Label { get; } = fieldKind.ToString() + "s";
}
