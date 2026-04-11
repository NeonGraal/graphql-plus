using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class ObjectsAliasedVerifier<TField>(IVerifierRepository verifiers, TypeKind fieldKind)
  : AliasedVerifier<IAstObject<TField>>(verifiers)
  where TField : IAstObjField
{
  public override string Label { get; } = fieldKind.ToString() + "s";
}
