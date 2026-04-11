using GqlPlus.Ast.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierTestsBase<IAstDualField>
{
  protected override IVerifyUsage<IAstObject<IAstDualField>> Verifier { get; }

  public VerifyDualTypesTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyDualAlternatesTests
  : ObjectVerifierAlternatesTestsBase<IAstDualField>
{
  protected override IVerifyUsage<IAstObject<IAstDualField>> Verifier { get; }

  public VerifyDualAlternatesTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyDualFieldsTests
  : ObjectVerifierFieldsTestsBase<IAstDualField>
{
  protected override IVerifyUsage<IAstObject<IAstDualField>> Verifier { get; }

  public VerifyDualFieldsTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(VerifierRepo);

  protected override ObjFieldBuilder<IAstDualField> MakeField(string fieldName, string fieldType)
    => new DualFieldBuilder(fieldName, fieldType);
}
