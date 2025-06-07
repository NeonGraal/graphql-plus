namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : ObjectVerifierTestsBase<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, IGqlpInputArg>
{
  private readonly IGqlpInputObject _input;

  protected override IGqlpInputObject TheObject => _input;
  protected override IVerifyUsage<IGqlpInputObject> Verifier { get; }

  public VerifyInputTypesTests()
  {
    Verifier = new VerifyInputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _input = A.Named<IGqlpInputObject>("Input");
  }

  [Fact]
  public void Verify_Input_WithFieldNullDefault_ReturnsError()
  {
    Define<IGqlpInputObject>("b");

    IGqlpFieldKey nullLabel = A.Error<IGqlpFieldKey>();
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = A.Error<IGqlpConstant>();
    nullValue.Value.Returns(nullLabel);

    IGqlpInputBase inType = A.Named<IGqlpInputBase>("b");
    IGqlpInputField field = A.Named<IGqlpInputField>("a");
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

    IGqlpFieldKey nullLabel = A.Error<IGqlpFieldKey>();
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = A.Error<IGqlpConstant>();
    nullValue.Value.Returns(nullLabel);

    IGqlpInputBase inType = A.Named<IGqlpInputBase>("b");
    IGqlpInputField field = A.Named<IGqlpInputField>("a");
    SetFieldType(field, inType);
    field.DefaultValue.Returns(nullValue);
    IGqlpModifier optional = A.Error<IGqlpModifier>();
    optional.ModifierKind.Returns(ModifierKind.Optional);
    field.Modifiers.Returns([optional]);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
