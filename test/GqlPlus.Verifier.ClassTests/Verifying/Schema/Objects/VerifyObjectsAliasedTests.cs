namespace GqlPlus.Verifying.Schema.Objects;

public abstract class VerifyObjectsAliasedTests<TObjField>(
  TypeKind fieldKind
) : AliasedVerifierTestsBase<IAstObject<TObjField>>
  where TObjField : IAstObjField
{
  internal override GroupedVerifier<IAstObject<TObjField>> NewGroupedVerifier()
    => new ObjectsAliasedVerifier<TObjField>(VerifierRepo, fieldKind);
}

[TracePerTest]
public class VerifyDualsAliasedTests()
  : VerifyObjectsAliasedTests<IAstDualField>(TypeKind.Dual)
{ }

[TracePerTest]
public class VerifyInputsAliasedTests()
  : VerifyObjectsAliasedTests<IAstInputField>(TypeKind.Input)
{ }

[TracePerTest]
public class VerifyOutputsAliasedTests()
  : VerifyObjectsAliasedTests<IAstOutputField>(TypeKind.Output)
{ }
