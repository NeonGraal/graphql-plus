namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierTestsBase<IGqlpDualField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpDualField>> Verifier { get; }

  public VerifyDualTypesTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(Verifiers);
}
