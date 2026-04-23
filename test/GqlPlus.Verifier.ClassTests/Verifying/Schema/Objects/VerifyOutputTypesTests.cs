using GqlPlus.Building;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : ObjectVerifierTestsBase<IAstOutputField>
{
  protected override IVerifyUsage<IAstObject<IAstOutputField>> Verifier { get; }

  public VerifyOutputTypesTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyOutputAlternatesTests
  : ObjectVerifierAlternatesTestsBase<IAstOutputField>
{
  protected override IVerifyUsage<IAstObject<IAstOutputField>> Verifier { get; }

  public VerifyOutputAlternatesTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyOutputFieldsTests
  : ObjectVerifierFieldsTestsBase<IAstOutputField>
{
  protected override IVerifyUsage<IAstObject<IAstOutputField>> Verifier { get; }

  public VerifyOutputFieldsTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(VerifierRepo);

  [Fact]
  public void Verify_Output_WithFieldParams_ReturnsNoErrors()
  {
    DefineObject("b");
    IAstObject<IAstInputField> paramType = A.Obj<IAstInputField>(TypeKind.Input, "c").AsObject;
    Define(paramType);

    IAstInputParam param = A.InputParam("c").AsInputParam;
    IAstOutputField field = A.OutputField("a", "b").WithParam(param).AsOutputField;
    TheBuilder.WithObjFields(field);

    Verify_NoErrors();
  }

  [Fact]
  public void Verify_Output_WithFieldParamModifiers_ReturnsNoErrors()
  {
    DefineObject("b");

    IAstObject<IAstInputField> paramType = A.Obj<IAstInputField>(TypeKind.Input, "c").AsObject;
    Define(paramType);
    Define<IAstEnum, IAstSimple>("d");

    IAstInputParam param = A.InputParam("c").WithModifier(ModifierKind.Dict, "d").AsInputParam;

    IAstOutputField field = A.OutputField("a", "b").WithParam(param).AsOutputField;

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  protected override ObjFieldBuilder<IAstOutputField> MakeField(string fieldName, string fieldType)
    => new OutputFieldBuilder(fieldName, fieldType);
}
