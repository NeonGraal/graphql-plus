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

    _output = A.Named<IGqlpOutputObject>("Output");
  }

  [Fact]
  public void Verify_Output_WithField_ReturnsNoErrors()
  {
    Define<IGqlpOutputObject>("b");
    Define<IGqlpInputObject>("c");

    IGqlpInputBase inType = A.Named<IGqlpInputBase>("c");
    IGqlpInputParam param = A.Error<IGqlpInputParam>();
    param.Type.Returns(inType);

    IGqlpOutputBase outType = A.Named<IGqlpOutputBase>("b");
    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
    SetFieldType(field, outType);
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
    Define<IGqlpOutputObject>("b");
    Define<IGqlpInputObject>("c");
    Define<IGqlpEnum>("d");

    IGqlpInputBase inType = A.Named<IGqlpInputBase>("c");
    IGqlpModifier modifier = A.Modifier(ModifierKind.Dict, "d");
    IGqlpInputParam param = A.Error<IGqlpInputParam>();
    param.Type.Returns(inType);
    param.Modifiers.Returns([modifier]);

    IGqlpOutputBase outType = A.Named<IGqlpOutputBase>("b");
    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
    SetFieldType(field, outType);
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
    Enum("b", "l");

    IGqlpOutputBase outType = A.Named<IGqlpOutputBase>("b");
    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
    field.EnumLabel.Returns("l");
    field.EnumType.Returns(outType);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumFieldUndefined_ReturnsError()
  {
    IGqlpOutputBase outType = A.Named<IGqlpOutputBase>("b");
    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
    field.EnumLabel.Returns("l");
    field.EnumType.Returns(outType);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumFieldWrongLabel_ReturnsError()
  {
    Enum("b", "c");

    IGqlpOutputBase outType = A.Named<IGqlpOutputBase>("b");
    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
    field.EnumLabel.Returns("l");
    field.EnumType.Returns(outType);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumLabel_ReturnsNoErrors()
  {
    Enum("b", "l");

    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
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
    IGqlpOutputField field = A.Named<IGqlpOutputField>("a");
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
    Enum("b", "l");

    IGqlpOutputObject other = A.Named<IGqlpOutputObject>("Other");
    IGqlpTypeParam typeParam = A.Named<IGqlpTypeParam>("a");
    typeParam.Constraint.Returns("b");
    other.TypeParams.Returns([typeParam]);
    IGqlpOutputBase parent = A.Named<IGqlpOutputBase>("a");
    parent.IsTypeParam.Returns(true);
    other.ObjParent.Returns(parent);

    IGqlpOutputField field = A.Named<IGqlpOutputField>("field");
    IGqlpOutputBase outputBase = A.Named<IGqlpOutputBase>("Other");
    IGqlpOutputArg arg = A.Named<IGqlpOutputArg>("l");
    arg.EnumLabel.Returns("");
    arg.EnumType.Returns(arg);
    arg.WhenForAnyArgs(a => a.SetEnumType(""))
      .Do(HandleSetEnumType);

    outputBase.Args.Returns([arg]);
    outputBase.BaseArgs.Returns([arg]);
    SetFieldType(field, outputBase);
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
    }
  }
}
