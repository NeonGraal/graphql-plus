﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class TypeInputModel(string Name)
  : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{ }

internal record class InputBaseModel(string Input)
  : TypeBaseModel<RefModel<InputBaseModel>>
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("input", Input);
}

internal record class InputFieldModel(string Name, RefModel<InputBaseModel> Type)
  : FieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; set; }
}

internal class InputModeller(
  IModeller<AstAlternate<InputReferenceAst>> alternate,
  IModeller<ModifierAst> modifier,
  IModeller<InputReferenceAst> reference
) : ModellerObject<InputDeclAst, InputReferenceAst, InputFieldAst, TypeInputModel, InputBaseModel, InputFieldModel>(alternate, modifier, reference)
{
  protected override InputFieldModel FieldModel(InputFieldAst field)
    => new(field.Name, new(BaseModel(field.Type))) {
      Modifiers = ModifiersModels(field.Modifiers),
    };

  internal override TypeInputModel ToModel(InputDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ParentModel(ast.Parent),
      Fields = FieldsModels(ast.Fields),
      Alternates = AlternatesModels(ast.Alternates),
    };
}

internal class InputReferenceModeller
  : ModellerBase<InputReferenceAst, InputBaseModel>
{
  internal override InputBaseModel ToModel(InputReferenceAst ast)
    => new(ast.Name);
}
