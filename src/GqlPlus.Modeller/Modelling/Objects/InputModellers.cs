﻿namespace GqlPlus.Modelling.Objects;

internal class InputModeller(
  ObjectModellers<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, InputBaseModel, InputFieldModel, InputAlternateModel> modellers
) : ModellerObject<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, modellers)
{
  protected override TypeInputModel ToModel(IGqlpInputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class InputArgModeller(
  IModeller<IGqlpDualArg, DualArgModel> dual
) : ModellerObjArg<IGqlpInputArg, InputArgModel>
{
  protected override InputArgModel ToModel(IGqlpInputArg ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(TypeKindModel.Dual, "", ast.Description) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(TypeKindModel.Input, ast.Name, ast.Description) {
      IsTypeParam = ast.IsTypeParam,
    };
}

internal class InputBaseModeller(
  IModeller<IGqlpInputArg, InputArgModel> objArg,
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpInputBase, IGqlpInputArg, InputBaseModel, InputArgModel>(objArg)
{
  protected override InputBaseModel ToModel(IGqlpInputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new("", ast.Description) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Name, ast.Description) {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<IGqlpInputBase, IGqlpInputField, InputBaseModel, InputFieldModel>(modifier, objBase)
{
  protected override InputFieldModel FieldModel(IGqlpInputField ast, InputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.BaseType.Description }, ast.Description) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
}

internal class InputAlternateModeller(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<IGqlpInputBase, InputBaseModel> objBase
) : ModellerObjAlternate<IGqlpInputBase, IGqlpInputAlternate, InputBaseModel, InputAlternateModel>(collection, objBase)
{
  protected override InputAlternateModel AlternateModel(InputBaseModel type)
    => new(type);
}

internal class InputParamModeller(
  IModifierModeller modifier,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpInputParam, InputParamModel>
{
  protected override InputParamModel ToModel(IGqlpInputParam ast, IMap<TypeKindModel> typeKinds)
  {
    InputParamModel model = new(ast.Type.Name, ast.Description) {
      IsTypeParam = ast.Type.IsTypeParam,
      Modifiers = modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
    return model;
  }
}
