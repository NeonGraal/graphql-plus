namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : ObjectDualVerifierTestsBase<IGqlpOutputObject, IGqlpOutputField>
{
  private readonly IGqlpOutputObject _output;

  protected override IGqlpOutputObject TheObject => _output;
  protected override IVerifyUsage<IGqlpOutputObject> Verifier { get; }

  public VerifyOutputTypesTests()
    : base(TypeKind.Output)
  {
    Verifier = new VerifyOutputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _output = A.Obj<IGqlpOutputObject>(TypeKind.Output, "Output");
  }

  [Fact]
  public void Verify_Output_WithFieldParams_ReturnsNoErrors()
  {
    DefineObject("b");
    IGqlpInputObject paramType = A.Obj<IGqlpInputObject>(TypeKind.Input, "c");
    Define(paramType);

    IGqlpInputParam param = A.InputParam("c");
    IGqlpOutputField field = ObjectField("a", "b", _output);
    field.Params.Returns([param]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithFieldParamModifiers_ReturnsNoErrors()
  {
    DefineObject("b");

    IGqlpInputObject paramType = A.Obj<IGqlpInputObject>(TypeKind.Input, "c");
    Define(paramType);
    Define<IGqlpEnum, IGqlpSimple>("d");

    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, "d");
    IGqlpInputParam param = A.InputParam("c");
    param.Modifiers.Returns([modifier]);

    IGqlpOutputField field = A.ObjField<IGqlpOutputField>("a", "b");
    field.Params.Returns([param]);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
