using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Schema.Objects;

public class InputFieldModelTests(
  IInputFieldModelChecks checks
) : TestObjectFieldModel<IGqlpInputField, IGqlpInputBase, InputFieldModel>(checks)
{
  [Theory, RepeatData]
  public void Model_DefaultString(FieldInput input, string contents)
    => checks.Field_Expected(
      new InputFieldAst(AstNulls.At, input.Name, new InputBaseAst(AstNulls.At, input.Type)) with {
        DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, contents))
      },
      checks.ExpectedField(input, ["default: " + contents.Quoted("'")], [])
      );
}

internal sealed class InputFieldModelChecks(
  IModeller<IGqlpInputField, InputFieldModel> modeller,
  IEncoder<InputFieldModel> encoding
) : CheckObjectFieldModel<IGqlpInputField, InputFieldAst, IGqlpInputBase, InputFieldModel>(modeller, encoding, TypeKindModel.Input)
  , IInputFieldModelChecks
{
  internal override InputFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, new InputBaseAst(AstNulls.At, input.Type)) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };
}

public interface IInputFieldModelChecks
  : ICheckObjectFieldModel<IGqlpInputField, InputFieldModel>
{ }
