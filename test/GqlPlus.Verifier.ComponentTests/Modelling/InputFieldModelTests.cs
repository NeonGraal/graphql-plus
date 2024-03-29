﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class InputFieldModelTests(
  IModeller<InputFieldAst, InputFieldModel> modeller
) : TestFieldModel<InputFieldAst, InputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void Model_DefaultString(FieldInput input, string contents)
    => FieldChecks.Field_Expected(
      FieldChecks.FieldAst(input) with { Default = new FieldKeyAst(AstNulls.At, contents) },
      FieldChecks.ExpectedField(input, ["default: " + _checks.YamlQuoted(contents)], [])
      );

  internal override ICheckFieldModel<InputFieldAst, InputReferenceAst> FieldChecks => _checks;

  private readonly InputFieldModelChecks _checks = new(modeller);
}

internal sealed class InputFieldModelChecks(
  IModeller<InputFieldAst, InputFieldModel> modeller
) : CheckFieldModel<InputFieldAst, InputReferenceAst, InputFieldModel>(modeller, TypeKindModel.Input)
{
  protected override InputFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new InputReferenceAst(AstNulls.At, input.Type));
}
