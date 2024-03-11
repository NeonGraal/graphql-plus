using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public record class TypeInputModel(
  string Name
) : TypeObjectModel<InputBaseModel, InputFieldModel>(TypeKindModel.Input, Name)
{ }

public record class InputBaseModel(
  string Input
) : ObjBaseModel<ObjRefModel<InputBaseModel>>
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("input", Input);
}

public record class InputFieldModel(
  string Name,
  ObjRefModel<InputBaseModel> Type
) : FieldModel<InputBaseModel>(Name, Type)
{
  internal ConstantModel? Default { get; set; }
}

internal class InputModeller(
  IAlternateModeller<InputReferenceAst, InputBaseModel> alternate,
  IModeller<InputFieldAst, InputFieldModel> field,
  IModeller<InputReferenceAst, InputBaseModel> reference
) : ModellerObject<InputDeclAst, InputReferenceAst, InputFieldAst, TypeInputModel, InputBaseModel, InputFieldModel>(alternate, field, reference)
{
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

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<InputReferenceAst, InputBaseModel> reference,
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<InputFieldAst, InputFieldModel>
{
  internal override InputFieldModel ToModel(InputFieldAst field)
    => new(field.Name, new(reference.ToModel(field.Type))) {
      Modifiers = modifier.ToModels<ModifierModel>(field.Modifiers),
      Default = constant.TryModel(field.Default),
    };
}
