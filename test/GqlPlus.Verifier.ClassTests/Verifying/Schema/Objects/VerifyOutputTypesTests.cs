using GqlPlus.Building;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : ObjectVerifierTestsBase<IGqlpOutputField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpOutputField>> Verifier { get; }

  public VerifyOutputTypesTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyOutputAlternatesTests
  : ObjectVerifierAlternatesTestsBase<IGqlpOutputField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpOutputField>> Verifier { get; }

  public VerifyOutputAlternatesTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyOutputFieldsTests
  : ObjectVerifierFieldsTestsBase<IGqlpOutputField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpOutputField>> Verifier { get; }

  public VerifyOutputFieldsTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(VerifierRepo);

  [Fact]
  public void Verify_Output_WithFieldParams_ReturnsNoErrors()
  {
    DefineObject("b");
    IGqlpObject<IGqlpInputField> paramType = A.Obj<IGqlpInputField>(TypeKind.Input, "c").AsObject;
    Define(paramType);

    IGqlpInputParam param = A.InputParam("c").AsInputParam;
    IGqlpOutputField field = A.OutputField("a", "b").WithParam(param).AsOutputField;
    TheBuilder.WithObjFields(field);

    Verify_NoErrors();
  }

  [Fact]
  public void Verify_Output_WithFieldParamModifiers_ReturnsNoErrors()
  {
    DefineObject("b");

    IGqlpObject<IGqlpInputField> paramType = A.Obj<IGqlpInputField>(TypeKind.Input, "c").AsObject;
    Define(paramType);
    Define<IGqlpEnum, IGqlpSimple>("d");

    IGqlpInputParam param = A.InputParam("c").WithModifier(ModifierKind.Dict, "d").AsInputParam;

    IGqlpOutputField field = A.OutputField("a", "b").WithParam(param).AsOutputField;

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  protected override ObjFieldBuilder<IGqlpOutputField> MakeField(string fieldName, string fieldType)
    => new OutputFieldBuilder(fieldName, fieldType);
}
