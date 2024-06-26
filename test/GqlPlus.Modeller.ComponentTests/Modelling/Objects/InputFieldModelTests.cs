using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputFieldModelTests(
  IModeller<IGqlpInputField, InputFieldModel> modeller,
  IRenderer<InputFieldModel> rendering
) : TestObjectFieldModel<IGqlpInputField, IGqlpInputBase>
{
  [Theory, RepeatData(Repeats)]
  public void Model_DefaultString(FieldInput input, string contents)
    => FieldChecks.Field_Expected(
      _checks.NewFieldAst(input, [], false) with { DefaultValue = new(new FieldKeyAst(AstNulls.At, contents)) },
      FieldChecks.ExpectedField(input, ["default: " + contents.YamlQuoted()], [])
      );

  internal override ICheckObjectFieldModel<IGqlpInputField> FieldChecks => _checks;

  private readonly InputFieldModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputFieldModelChecks(
  IModeller<IGqlpInputField, InputFieldModel> modeller,
  IRenderer<InputFieldModel> rendering
) : CheckObjectFieldModel<IGqlpInputField, InputFieldAst, IGqlpInputBase, InputFieldModel>(modeller, rendering, TypeKindModel.Input)
{
  internal override InputFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, new InputBaseAst(AstNulls.At, input.Type)) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };
}
