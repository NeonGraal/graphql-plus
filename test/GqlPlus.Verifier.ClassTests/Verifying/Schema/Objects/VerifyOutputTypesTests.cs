using GqlPlus.Abstractions.Schema;
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
    Verifier = new VerifyOutputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ConstraintDelegate, LoggerFactory));

    _output = NFor<IGqlpOutputObject>("Output");
  }

  [Fact]
  public void Verify_Output_WithField_ReturnsNoErrors()
  {
    Define<IGqlpOutputObject>("b");
    Define<IGqlpInputObject>("c");

    IGqlpInputBase inType = NFor<IGqlpInputBase>("c");
    IGqlpInputParam param = EFor<IGqlpInputParam>();
    param.Type.Returns(inType);

    IGqlpOutputBase outType = NFor<IGqlpOutputBase>("b");
    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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

    IGqlpInputBase inType = NFor<IGqlpInputBase>("c");
    IGqlpModifier modifier = For<IGqlpModifier>();
    modifier.ModifierKind.Returns(ModifierKind.Dict);
    modifier.Key.Returns("d");
    IGqlpInputParam param = EFor<IGqlpInputParam>();
    param.Type.Returns(inType);
    param.Modifiers.Returns([modifier]);

    IGqlpOutputBase outType = NFor<IGqlpOutputBase>("b");
    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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

    IGqlpOutputBase outType = NFor<IGqlpOutputBase>("b");
    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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
    IGqlpOutputBase outType = NFor<IGqlpOutputBase>("b");
    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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

    IGqlpOutputBase outType = NFor<IGqlpOutputBase>("b");
    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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

    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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
    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
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

    IGqlpOutputObject other = NFor<IGqlpOutputObject>("Other");
    IGqlpTypeParam typeParam = NFor<IGqlpTypeParam>("a");
    typeParam.Constraint.Returns("b");
    other.TypeParams.Returns([typeParam]);
    IGqlpOutputBase parent = NFor<IGqlpOutputBase>("a");
    parent.IsTypeParam.Returns(true);
    other.ObjParent.Returns(parent);

    IGqlpOutputField field = NFor<IGqlpOutputField>("field");
    IGqlpOutputBase outputBase = NFor<IGqlpOutputBase>("Other");
    IGqlpOutputArg arg = NFor<IGqlpOutputArg>("l");
    arg.EnumLabel.Returns("");
    arg.EnumType.Returns(arg);
    arg.WhenForAnyArgs(a => a.SetEnumType(""))
      .Do(HandleSetEnumType);

    outputBase.Args.Returns([arg]);
    outputBase.BaseArgs.Returns([arg]);
    SetFieldType(field, outputBase);

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
