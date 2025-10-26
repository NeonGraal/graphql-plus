using GqlPlus.Building;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : ObjectDualVerifierTestsBase<IGqlpOutputObject, IGqlpOutputField>
{
  protected override IVerifyUsage<IGqlpOutputObject> Verifier { get; }

  public VerifyOutputTypesTests()
    : base(TypeKind.Output)
    => Verifier = new VerifyOutputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate));

  [Fact]
  public void Verify_Output_WithFieldParams_ReturnsNoErrors()
  {
    DefineObject("b");
    IGqlpInputObject paramType = A.Obj<IGqlpInputObject, IGqlpInputField>(TypeKind.Input, "c").AsObject;
    Define(paramType);

    IGqlpInputParam param = A.InputParam("c").AsInputParam;
    IGqlpOutputField field = A.OutputField("a", "b").WithParams([param]).AsOutputField;
    TheBuilder.WithObjFields(field);

    Verify_NoErrors();
  }

  [Fact]
  public void Verify_Output_WithFieldParamModifiers_ReturnsNoErrors()
  {
    DefineObject("b");

    IGqlpInputObject paramType = A.Obj<IGqlpInputObject, IGqlpInputField>(TypeKind.Input, "c").AsObject;
    Define(paramType);
    Define<IGqlpEnum, IGqlpSimple>("d");

    IGqlpInputParam param = A.InputParam("c").WithModifier(ModifierKind.Dict, "d").AsInputParam;

    IGqlpOutputField field = A.OutputField("a", "b").WithParams(param).AsOutputField;

    TheObject.Fields.Returns([field]);
    TheObject.ObjFields.Returns([field]);

    Usages.Add(TheObject);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
