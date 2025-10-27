namespace GqlPlus.Verifying.Schema.Objects;

public abstract class VerifyObjectsAliasedTests<TObjField>(
  TypeKind kind
) : AliasedVerifierTestsBase<IGqlpObject<TObjField>>
  where TObjField : IGqlpObjField
{
  internal override GroupedVerifier<IGqlpObject<TObjField>> NewGroupedVerifier()
    => new ObjectsAliasedVerifier<TObjField>(Definition, Merger, LoggerFactory, new FieldObjectKind<TObjField>(kind));
}
