using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Objects;

public class InputFieldModelTests(
  IModeller<IGqlpInputField, InputFieldModel> modeller,
  IRenderer<InputFieldModel> rendering
) : TestObjectFieldModel<IGqlpInputField, InputFieldAst, IGqlpInputBase>
{
  [Theory, RepeatData(Repeats)]
  public void Model_DefaultString(FieldInput input, string contents)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with { DefaultValue = new FieldKeyAst(AstNulls.At, contents) },
      FieldChecks.ExpectedField(input, ["default: " + contents.YamlQuoted()], [])
      );

  internal override ICheckObjectFieldModel<InputFieldAst, IGqlpInputBase> FieldChecks => _checks;

  private readonly InputFieldModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputFieldModelChecks(
  IModeller<IGqlpInputField, InputFieldModel> modeller,
  IRenderer<InputFieldModel> rendering
) : CheckObjectFieldModel<IGqlpInputField, InputFieldAst, IGqlpInputBase, InputFieldModel>(modeller, rendering, TypeKindModel.Input)
{
  protected override InputFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new InputBaseAst(AstNulls.At, input.Type));
}
