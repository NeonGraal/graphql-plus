using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputFieldModelTests(
  IModeller<InputFieldAst, InputFieldModel> modeller
) : TestObjectFieldModel<InputFieldAst, InputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_DefaultString(FieldInput input, string contents)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with { DefaultValue = new FieldKeyAst(AstNulls.At, contents) },
      FieldChecks.ExpectedField(input, ["default: " + contents.YamlQuoted()], [])
      );

  internal override ICheckObjectFieldModel<InputFieldAst, InputBaseAst> FieldChecks => _checks;

  private readonly InputFieldModelChecks _checks = new(modeller);
}

internal sealed class InputFieldModelChecks(
  IModeller<InputFieldAst, InputFieldModel> modeller
) : CheckObjectFieldModel<InputFieldAst, InputBaseAst, InputFieldModel>(modeller, TypeKindModel.Input)
{
  protected override InputFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new InputBaseAst(AstNulls.At, input.Type));
}
