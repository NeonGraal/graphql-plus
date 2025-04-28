using GqlPlus.Abstractions.Schema;
using NSubstitute;

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
    field.Params.Returns([param]);

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

    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Output_WithEnumLabel_ReturnsNoErrors()
  {
    Enum("b", "l");

    IGqlpOutputField field = NFor<IGqlpOutputField>("a");
    field.EnumLabel.Returns("l");

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

    _output.ObjFields.Returns([field]);

    Usages.Add(_output);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }
}
