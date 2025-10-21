namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : ObjectDualVerifierTestsBase<IGqlpInputObject, IGqlpInputField>
{
  private readonly IGqlpInputObject _input;

  protected override IGqlpInputObject TheObject => _input;
  protected override IVerifyUsage<IGqlpInputObject> Verifier { get; }

  public VerifyInputTypesTests()
    : base(TypeKind.Input)
  {
    Verifier = new VerifyInputTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _input = A.Obj<IGqlpInputObject>(TypeKind.Input, "Input").AsObject;
  }

  [Theory, RepeatData]
  public void Verify_Input_WithFieldNullDefault_ReturnsError(string fieldName, string fieldType)
  {
    DefineObject(fieldType);

    IGqlpFieldKey nullLabel = A.EnumFieldKey("Null", "null");
    IGqlpConstant nullValue = A.Constant(nullLabel);

    IGqlpInputField field = ObjectField(fieldName, fieldType);
    field.DefaultValue.Returns(nullValue);

    Verify_Errors("'null' default requires Optional type");
  }

  [Theory, RepeatData]
  public void Verify_Input_WithOptionalFieldNullDefault_ReturnsNoErrors(string fieldName, string fieldType)
  {
    DefineObject(fieldType);

    IGqlpFieldKey nullLabel = A.EnumFieldKey("Null", "null");
    IGqlpConstant nullValue = A.Constant(nullLabel);

    IGqlpInputField field = SetModifier(ObjectField(fieldName, fieldType), ModifierKind.Optional);
    field.DefaultValue.Returns(nullValue);

    Verify_NoErrors();
  }
}
