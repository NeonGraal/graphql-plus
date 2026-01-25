using GqlPlus.Building;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : ObjectVerifierTestsBase<IGqlpInputField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpInputField>> Verifier { get; }

  public VerifyInputTypesTests()
    : base(TypeKind.Input)
    => Verifier = new VerifyInputTypes(Verifiers);
}

[TracePerTest]
public class VerifyInputAlternatesTests
  : ObjectVerifierAlternatesTestsBase<IGqlpInputField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpInputField>> Verifier { get; }

  public VerifyInputAlternatesTests()
    : base(TypeKind.Input)
    => Verifier = new VerifyInputTypes(Verifiers);
}

[TracePerTest]
public class VerifyInputFieldsTests
  : ObjectVerifierFieldsTestsBase<IGqlpInputField>
{
  protected override IVerifyUsage<IGqlpObject<IGqlpInputField>> Verifier { get; }

  public VerifyInputFieldsTests()
    : base(TypeKind.Input)
    => Verifier = new VerifyInputTypes(Verifiers);

  [Theory, RepeatData]
  public void Verify_Input_WithFieldNullDefault_ReturnsError(string fieldName, string fieldType)
  {
    DefineObject(fieldType);

    IGqlpFieldKey nullLabel = A.EnumFieldKey(BuiltIn.NullType, BuiltIn.NullValue);
    IGqlpConstant nullValue = A.Constant(nullLabel);

    IGqlpInputField field = A.InputField(fieldName, fieldType).WithDefault(nullValue).AsInputField;
    TheBuilder.WithObjFields(field);

    Verify_Errors("'null' default requires Optional type");
  }

  [Theory, RepeatData]
  public void Verify_Input_WithOptionalFieldNullDefault_ReturnsNoErrors(string fieldName, string fieldType)
  {
    DefineObject(fieldType);

    IGqlpFieldKey nullLabel = A.EnumFieldKey(BuiltIn.NullType, BuiltIn.NullValue);
    IGqlpConstant nullValue = A.Constant(nullLabel);

    IGqlpInputField field = A.InputField(fieldName, fieldType)
      .WithModifier(ModifierKind.Opt)
      .WithDefault(nullValue)
      .AsInputField;

    TheBuilder.WithObjFields(field);

    Verify_NoErrors();
  }
}
