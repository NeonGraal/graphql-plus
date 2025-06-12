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

    IGqlpFieldKey nullLabel = A.FieldKey("null");
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = A.Constant(nullLabel);

    IGqlpInputField field = A.InputField("a", "b");
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

    IGqlpFieldKey nullLabel = A.FieldKey("null");
    nullLabel.EnumValue.Returns("Null.null");

    IGqlpConstant nullValue = A.Constant(nullLabel);

    IGqlpModifier optional = A.Modifier(ModifierKind.Optional);
    IGqlpInputField field = A.InputField("a", "b", optional);
    field.DefaultValue.Returns(nullValue);

    _input.Fields.Returns([field]);
    _input.ObjFields.Returns([field]);

    Usages.Add(_input);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
