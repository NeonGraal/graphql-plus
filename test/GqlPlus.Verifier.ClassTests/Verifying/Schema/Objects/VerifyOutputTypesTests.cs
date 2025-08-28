using NSubstitute.Core;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : ObjectVerifierTestsBase<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputArg>
{
  private readonly IGqlpOutputObject _output;

  protected override IGqlpOutputObject TheObject => _output;
  protected override IVerifyUsage<IGqlpOutputObject> Verifier { get; }

  public VerifyOutputTypesTests()
  {
    Verifier = new VerifyOutputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _output = A.Obj<IGqlpOutputObject, IGqlpOutputBase>("Output");
  }

  [Fact]
  public void Verify_Output_WithField_ReturnsNoErrors()
  {
    IGqlpOutputObject fieldType = A.Obj<IGqlpOutputObject, IGqlpOutputBase>("b");
    IGqlpInputObject paramType = A.Obj<IGqlpInputObject, IGqlpInputBase>("c");
    Define(fieldType, paramType);

    IGqlpInputParam param = A.InputParam("c");
    IGqlpOutputField field = A.OutputField("a", "b");
    field.Params.Returns([param]);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithFieldModifiers_ReturnsNoErrors()
  {
    IGqlpOutputObject fieldType = A.Obj<IGqlpOutputObject, IGqlpOutputBase>("b");
    IGqlpInputObject paramType = A.Obj<IGqlpInputObject, IGqlpInputBase>("c");
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

  [Fact]
  public void Verify_Output_WithEnumField_ReturnsNoErrors()
  {
    AddTypes(A.Enum("b", ["l"]));

    IGqlpOutputField field = A.OutputField("a", "b");
    field.EnumLabel.Returns("l");
    field.EnumType.Returns(field.Type);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumFieldUndefined_ReturnsError()
  {
    IGqlpOutputField field = A.OutputField("a", "b");
    field.EnumLabel.Returns("l");
    field.EnumType.Returns(field.Type);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumFieldWrongLabel_ReturnsError()
  {
    AddTypes(A.Enum("b", ["c"]));

    IGqlpOutputField field = A.OutputField("a", "b");
    field.EnumLabel.Returns("l");
    field.EnumType.Returns(field.Type);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumLabel_ReturnsNoErrors()
  {
    AddTypes(A.Enum("b", ["l"]));

    IGqlpOutputField field = A.OutputField("a", "b");
    field.EnumLabel.Returns("l");

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithUndefinedEnumLabel_ReturnsError()
  {
    IGqlpOutputField field = A.OutputField("a", "b");
    field.EnumLabel.Returns("l");

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumTypeArg_ReturnsNoErrors()
  {
    AddTypes(A.Enum("b", ["l"]));

    IGqlpTypeParam typeParam = A.TypeParam("a", "b");
    IGqlpOutputBase parent = A.OutputBase("a", isTypeParam: true);
    IGqlpOutputObject other = A.Obj<IGqlpOutputObject, IGqlpOutputBase>("other");
    other.TypeParams.Returns([typeParam]);
    other.ObjParent.Returns(parent);

    IGqlpOutputArg arg = A.OutputEnumArg("l", "l", "");
    arg.WhenForAnyArgs(a => a.SetEnumType(""))
      .Do(HandleSetEnumType);

    IGqlpOutputBase typeBase = A.OutputBase("other").SetArgs(arg);
    IGqlpOutputField field = A.ObjField<IGqlpOutputField, IGqlpOutputBase>("field", typeBase);

    ArgMatcher.Matches(arg, "b", Arg.Any<EnumContext>()).Returns(true);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();

    void HandleSetEnumType(CallInfo c)
    {
      arg.EnumLabel.Returns("l");
      arg.Name.Returns("b");
      arg.EnumType.Name.Returns("b");
    }
  }
}
