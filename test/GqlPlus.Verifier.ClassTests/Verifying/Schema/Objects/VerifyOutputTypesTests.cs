namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : ObjectDualVerifierTestsBase<IGqlpOutputObject, IGqlpOutputField>
{
  private readonly IGqlpOutputObject _output;

  protected override IGqlpOutputObject TheObject => _output;
  protected override IVerifyUsage<IGqlpOutputObject> Verifier { get; }

  public VerifyOutputTypesTests()
  {
    Verifier = new VerifyOutputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _output = A.Obj<IGqlpOutputObject>("Output");
  }

  [Fact]
  public void Verify_Output_WithFieldParams_ReturnsNoErrors()
  {
    DefineObject("b");
    IGqlpInputObject paramType = A.Obj<IGqlpInputObject>("c");
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
    IGqlpOutputObject fieldType = A.Obj<IGqlpOutputObject>("b");
    IGqlpInputObject paramType = A.Obj<IGqlpInputObject>("c");
    Define(fieldType, paramType);
    Define<IGqlpEnum, IGqlpSimple>("d");

    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, "d");
    IGqlpInputParam param = A.InputParam("c");
    param.Modifiers.Returns([modifier]);

    IGqlpOutputField field = A.OutputField("a", "b");
    field.Params.Returns([param]);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
