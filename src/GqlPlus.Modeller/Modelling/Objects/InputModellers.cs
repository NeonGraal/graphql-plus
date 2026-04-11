using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

internal class InputModeller(
  ObjectModellers<IAstInputField, InputFieldModel> modellers
) : ModellerObject<IAstObject<IAstInputField>, IAstInputField, TypeInputModel, InputFieldModel>(TypeKindModel.Input, modellers)
{
  protected override TypeInputModel ToModel(IAstObject<IAstInputField> ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IAstObjBase, ObjBaseModel> objBase,
  IModeller<IAstConstant, ConstantModel> constant
) : ModellerObjField<IAstInputField, InputFieldModel>(modifier, objBase)
{
  protected override InputFieldModel FieldModel(IAstInputField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.Type.Description.IfWhiteSpace() }, ast.Description) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
}

internal class InputParamModeller(
  IModifierModeller modifier,
  IModeller<IAstConstant, ConstantModel> constant
) : ModellerBase<IAstInputParam, InputParamModel>
{
  protected override InputParamModel ToModel(IAstInputParam ast, IMap<TypeKindModel> typeKinds)
  {
    InputParamModel model = new(ast.Type.Name, ast.Description) {
      IsTypeParam = ast.Type.IsTypeParam,
      Modifiers = modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
    return model;
  }
}
