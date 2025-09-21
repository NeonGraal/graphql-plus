﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class InputFieldModelTests(
  IInputFieldModelChecks checks
) : TestObjectFieldModel<IGqlpInputField, InputFieldModel>(checks)
{
  [Theory, RepeatData]
  public void Model_DefaultString(FieldInput input, string contents)
    => checks.Field_Expected(
      new InputFieldAst(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) with {
        DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, contents))
      },
      checks.ExpectedField(input, ["default: " + contents.Quoted("'")], [])
      );
}

internal sealed class InputFieldModelChecks(
  IModeller<IGqlpInputField, InputFieldModel> modeller,
  IEncoder<InputFieldModel> encoding
) : CheckObjectFieldModel<IGqlpInputField, InputFieldAst, InputFieldModel>(modeller, encoding, TypeKindModel.Input)
  , IInputFieldModelChecks
{
  internal override InputFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, new ObjBaseAst(AstNulls.At, input.Type, "")) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };
}

public interface IInputFieldModelChecks
  : ICheckObjectFieldModel<IGqlpInputField, InputFieldModel>
{ }
