using GqlPlus.Building.Schema.Objects;

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

[TracePerTest]
public class VerifyDualAlternatesTests
  : ObjectVerifierAlternatesTestsBase<IGqlpDualField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpDualField>> Verifier { get; }

  public VerifyDualAlternatesTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(Verifiers);
}

[TracePerTest]
public class VerifyDualFieldsTests
  : ObjectVerifierFieldsTestsBase<IGqlpDualField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpDualField>> Verifier { get; }

  public VerifyDualFieldsTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(Verifiers);

  protected override ObjFieldBuilder<IGqlpDualField> MakeField(string fieldName, string fieldType)
    => new DualFieldBuilder(fieldName, fieldType);
}
