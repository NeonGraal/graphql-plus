using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : UsageVerifierBase<IGqlpInputObject>
{
  private readonly ForM<IGqlpInputField> _fields = new();
  private readonly ForM<IGqlpInputAlternate> _mergeAlternates = new();
  private readonly VerifyInputTypes _verifier;

  private readonly IGqlpInputObject _input;

  public VerifyInputTypesTests()
  {
    _verifier = new(Aliased.Intf, _fields.Intf, _mergeAlternates.Intf, Logger);

    _input = NFor<IGqlpInputObject>("Input");
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
  public void Verify_Input_ReturnsNoErrors()
  {
    Usages.Add(_input);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Input_WithTypeParams_ReturnsNoErrors()
  {
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    _input.TypeParams.Returns(typeParams);
    IGqlpInputBase parent = NFor<IGqlpInputBase>("a");
    parent.IsTypeParam.Returns(true);
    _input.ObjParent.Returns(parent);

    Usages.Add(_input);
    Definitions.Add(_input);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Input_WithFieldNullDefault_ReturnsError()
  {
    Define<IGqlpInputObject>("b");

    IGqlpFieldKey nullLabel = EFor<IGqlpFieldKey>();
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = EFor<IGqlpConstant>();
    nullValue.Value.Returns(nullLabel);

    IGqlpInputBase inType = NFor<IGqlpInputBase>("b");
    IGqlpInputField field = NFor<IGqlpInputField>("a");
    field.Type.Returns(inType);
    field.BaseType.Returns(inType);
    field.DefaultValue.Returns(nullValue);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_Input_WithOptionalFieldNullDefault_ReturnsNoErrors()
  {
    Define<IGqlpInputObject>("b");

    IGqlpFieldKey nullLabel = EFor<IGqlpFieldKey>();
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = EFor<IGqlpConstant>();
    nullValue.Value.Returns(nullLabel);

    IGqlpInputBase inType = NFor<IGqlpInputBase>("b");
    IGqlpInputField field = NFor<IGqlpInputField>("a");
    field.Type.Returns(inType);
    field.BaseType.Returns(inType);
    field.DefaultValue.Returns(nullValue);
    IGqlpModifier optional = EFor<IGqlpModifier>();
    optional.ModifierKind.Returns(ModifierKind.Optional);
    field.Modifiers.Returns([optional]);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
