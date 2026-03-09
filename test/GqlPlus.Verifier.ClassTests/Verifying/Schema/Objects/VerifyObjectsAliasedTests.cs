namespace GqlPlus.Verifying.Schema.Objects;

public abstract class VerifyObjectsAliasedTests<TObjField>
  : AliasedVerifierTestsBase<IGqlpObject<TObjField>>
  where TObjField : IGqlpObjField
{
  protected VerifyObjectsAliasedTests(TypeKind kind)
    => VerifierRepo.FieldKindFor<TObjField>().Returns(new FieldObjectKind<TObjField>(kind));

  internal override GroupedVerifier<IGqlpObject<TObjField>> NewGroupedVerifier()
    => new ObjectsAliasedVerifier<TObjField>(VerifierRepo);
}

[TracePerTest]
public class VerifyDualsAliasedTests()
  : VerifyObjectsAliasedTests<IGqlpDualField>(TypeKind.Dual)
{ }

[TracePerTest]
public class VerifyInputsAliasedTests()
  : VerifyObjectsAliasedTests<IGqlpInputField>(TypeKind.Input)
{ }

[TracePerTest]
public class VerifyOutputsAliasedTests()
  : VerifyObjectsAliasedTests<IGqlpOutputField>(TypeKind.Output)
{ }
