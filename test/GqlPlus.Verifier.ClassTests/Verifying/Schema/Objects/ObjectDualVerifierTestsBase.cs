namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectDualVerifierTestsBase<TObject, TField>(
  TypeKind kind
) : ObjectVerifierTestsBase<TObject, TField>(kind)
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{ }
