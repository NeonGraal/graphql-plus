namespace GqlPlus.Verifying.Schema.Objects;

public abstract class VerifyObjectsAliasedTests<TObjField>(
  TypeKind kind
) : AliasedVerifierTestsBase<IGqlpObject<TObjField>>
  where TObjField : IGqlpObjField
{
  internal override GroupedVerifier<IGqlpObject<TObjField>> NewGroupedVerifier()
    => new ObjectsAliasedVerifier<TObjField>(Definition, Merger, LoggerFactory, new FieldObjectKind<TObjField>(kind));
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
