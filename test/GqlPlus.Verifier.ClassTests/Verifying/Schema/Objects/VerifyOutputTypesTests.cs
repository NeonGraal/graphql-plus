using GqlPlus.Abstractions.Schema;
using NSubstitute;
using NSubstitute.Core;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputTypesTests
  : UsageVerifierBase<IGqlpOutputObject>
{
  private readonly ForM<IGqlpOutputField> _fields = new();
  private readonly ForM<IGqlpOutputAlternate> _mergeAlternates = new();
  private readonly VerifyOutputTypes _verifier;

  private readonly IGqlpOutputObject _output;

  public VerifyOutputTypesTests()
  {
    _verifier = new(Aliased.Intf, _fields.Intf, _mergeAlternates.Intf, Logger);

    _output = NFor<IGqlpOutputObject>("Output");
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      _fields.NotCalled,
      _mergeAlternates.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Output_ReturnsNoErrors()
  {
    Usages.Add(_output);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithTypeParams_ReturnsNoErrors()
  {
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    _output.TypeParams.Returns(typeParams);
    IGqlpOutputBase parent = NFor<IGqlpOutputBase>("a");
    parent.IsTypeParam.Returns(true);
    _output.ObjParent.Returns(parent);

    Usages.Add(_output);
    Definitions.Add(_output);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
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
    field.Type.Returns(outType);
    field.BaseType.Returns(outType);
    field.Params.Returns([param]);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    _verifier.Verify(UsageAliased, Errors);

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

    _verifier.Verify(UsageAliased, Errors);

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

    _verifier.Verify(UsageAliased, Errors);

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

    _verifier.Verify(UsageAliased, Errors);

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

    _verifier.Verify(UsageAliased, Errors);

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

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumTypeArg_ReturnsNoErrors()
  {
    Enum("b", "l");

    IGqlpOutputObject other = NFor<IGqlpOutputObject>("Other");
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    other.TypeParams.Returns(typeParams);
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
    field.Type.Returns(outputBase);
    field.BaseType.Returns(outputBase);

    _output.Fields.Returns([field]);
    _output.ObjFields.Returns([field]);

    Usages.Add(_output);
    Definitions.Add(other);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();

    void HandleSetEnumType(CallInfo c)
    {
      arg.EnumLabel.Returns("l");
      arg.Name.Returns("b");
    }
  }
}
