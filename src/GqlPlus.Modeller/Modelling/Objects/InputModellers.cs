namespace GqlPlus.Modelling.Objects;

internal class InputModeller(
  IModeller<IGqlpInputAlternate, InputAlternateModel> alternate,
  IModeller<IGqlpInputField, InputFieldModel> objField,
  IModeller<IGqlpInputBase, InputBaseModel> objBase
) : ModellerObject<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, alternate, objField, objBase)
{
  protected override TypeInputModel ToModel(IGqlpInputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class InputArgModeller(
  IModeller<IGqlpDualArg, DualArgModel> dual
) : ModellerObjArg<IGqlpInputArg, InputArgModel>
{
  protected override InputArgModel ToModel(IGqlpInputArg ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Input, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new("") {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Input) {
      IsTypeParam = ast.IsTypeParam,
    };
}

internal class InputBaseModeller(
  IModeller<IGqlpInputArg, InputArgModel> objArg,
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpInputBase, IGqlpInputArg, InputBaseModel, InputArgModel>(objArg)
{
  protected override InputBaseModel ToModel(IGqlpInputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Input, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new("") {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Input) {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> refBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<IGqlpInputBase, IGqlpInputField, InputBaseModel, InputFieldModel>(modifier, refBase)
{
  protected override InputFieldModel FieldModel(IGqlpInputField ast, InputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, new(type, ast.Type.Description), ast.Description) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
}

internal class InputAlternateModeller(
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjAlternate<IGqlpInputBase, IGqlpInputAlternate, InputBaseModel, InputAlternateModel>(objBase, collection)
{
  protected override InputAlternateModel AlternateModel(IGqlpInputAlternate ast, InputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(new ObjDescribedModel<InputBaseModel>(type, ast.Type.Description));
}

internal class InputParamModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpInputParam, InputParamModel>
{
  protected override InputParamModel ToModel(IGqlpInputParam ast, IMap<TypeKindModel> typeKinds)
  {
    InputBaseModel typeModel = objBase.ToModel(ast.Type, typeKinds);
    return new(new(typeModel, ast.Type.Description)) {
      Modifiers = modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
  }
}
