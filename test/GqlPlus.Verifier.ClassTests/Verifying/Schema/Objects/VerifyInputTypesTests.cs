using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : ObjectVerifierBase<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>
{
  private readonly IGqlpInputObject _input;

  protected override IGqlpInputObject TheObject => _input;
  protected override IVerifyUsage<IGqlpInputObject> Verifier { get; }

  public VerifyInputTypesTests()
  {
    Verifier = new VerifyInputTypes(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, LoggerFactory);

    _input = NFor<IGqlpInputObject>("Input");
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

    Verifier.Verify(UsageAliased, Errors);

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
    SetFieldType(field, inType);
    field.DefaultValue.Returns(nullValue);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    Verifier.Verify(UsageAliased, Errors);

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
    SetFieldType(field, inType);
    field.DefaultValue.Returns(nullValue);
    IGqlpModifier optional = EFor<IGqlpModifier>();
    optional.ModifierKind.Returns(ModifierKind.Optional);
    field.Modifiers.Returns([optional]);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
