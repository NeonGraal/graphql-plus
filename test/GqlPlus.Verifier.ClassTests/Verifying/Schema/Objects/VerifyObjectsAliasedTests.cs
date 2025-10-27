namespace GqlPlus.Verifying.Schema.Objects;

public abstract class VerifyObjectsAliasedTests<TField>(
  TypeKind kind
) : AliasedVerifierTestsBase<IGqlpObject<TField>>
  where TField : IGqlpObjField
{
  internal override GroupedVerifier<IGqlpObject<TField>> NewGroupedVerifier()
    => new ObjectsAliasedVerifier<TField>(Definition, Merger, LoggerFactory, new FieldObjectKind<TField>(kind));
}
