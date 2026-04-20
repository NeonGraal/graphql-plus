using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Building;
using GqlPlus.Building.Schema;
using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputTypesTests
  : ObjectVerifierTestsBase<IAstInputField>
{
  protected override IVerifyUsage<IAstObject<IAstInputField>> Verifier { get; }

  public VerifyInputTypesTests()
    : base(TypeKind.Input)
    => Verifier = new VerifyInputTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyInputAlternatesTests
  : ObjectVerifierAlternatesTestsBase<IAstInputField>
{
  protected override IVerifyUsage<IAstObject<IAstInputField>> Verifier { get; }

  public VerifyInputAlternatesTests()
    : base(TypeKind.Input)
    => Verifier = new VerifyInputTypes(VerifierRepo);
}

[TracePerTest]
public class VerifyInputFieldsTests
  : ObjectVerifierFieldsTestsBase<IAstInputField>
{
  protected override IVerifyUsage<IAstObject<IAstInputField>> Verifier { get; }

  public VerifyInputFieldsTests()
    : base(TypeKind.Input)
    => Verifier = new VerifyInputTypes(VerifierRepo);

  [Theory, RepeatData]
  public void Verify_Input_WithFieldNullDefault_ReturnsError(string fieldName, string fieldType)
  {
    DefineObject(fieldType);

    IAstFieldKey nullLabel = A.EnumFieldKey(BuiltIn.NullType, BuiltIn.NullValue);
    IAstConstant nullValue = A.Constant(nullLabel);

    IAstInputField field = A.InputField(fieldName, fieldType).WithDefault(nullValue).AsInputField;
    TheBuilder.WithObjFields(field);

    Verify_Errors("'null' default requires Optional type");
  }

  [Theory, RepeatData]
  public void Verify_Input_WithOptionalFieldNullDefault_ReturnsNoErrors(string fieldName, string fieldType)
  {
    DefineObject(fieldType);

    IAstFieldKey nullLabel = A.EnumFieldKey(BuiltIn.NullType, BuiltIn.NullValue);
    IAstConstant nullValue = A.Constant(nullLabel);

    IAstInputField field = A.InputField(fieldName, fieldType)
      .WithModifier(ModifierKind.Opt)
      .WithDefault(nullValue)
      .AsInputField;

    TheBuilder.WithObjFields(field);

    Verify_NoErrors();
  }

  protected override ObjFieldBuilder<IAstInputField> MakeField(string fieldName, string fieldType)
    => new InputFieldBuilder(fieldName, fieldType);
}
