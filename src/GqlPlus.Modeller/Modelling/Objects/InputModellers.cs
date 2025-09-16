namespace GqlPlus.Modelling.Objects;

internal class InputModeller(
  ObjectModellers<IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, InputFieldModel> modellers
) : ModellerObject<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel, InputFieldModel>(TypeKindModel.Input, modellers)
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

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, ObjBaseModel> objBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<IGqlpInputBase, IGqlpInputField, InputFieldModel>(modifier, objBase)
{
  protected override InputFieldModel FieldModel(IGqlpInputField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.BaseType.Description }, ast.Description) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
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
