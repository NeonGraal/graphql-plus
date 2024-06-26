namespace GqlPlus.Modelling.Objects;

internal class InputModeller(
  IModeller<IGqlpInputAlternate, InputAlternateModel> alternate,
  IModeller<IGqlpInputField, InputFieldModel> objField,
  IModeller<IGqlpInputBase, InputBaseModel> objBase
) : ModellerObject<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>(TypeKindModel.Input, alternate, objField, objBase)
{
  protected override TypeInputModel ToModel(IGqlpInputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class InputBaseModeller(
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpInputBase, InputBaseModel>
{
  protected override InputBaseModel ToModel(IGqlpInputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Input, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Input) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Input) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> refBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<IGqlpInputBase, IGqlpInputField, InputBaseModel, InputFieldModel>(modifier, refBase)
{
  protected override InputFieldModel FieldModel(IGqlpInputField ast, InputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, new(type, ast.Type.Description)) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
}

internal class InputAlternateModeller(
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjAlternate<IGqlpInputBase, IGqlpInputAlternate, InputBaseModel, InputAlternateModel>(objBase, collection)
{
  protected override InputAlternateModel AlternateModel(IGqlpInputAlternate ast, InputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(new(type, ast.Type.Description));
}

internal class InputParameterModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpInputParameter, InputParameterModel>
{
  protected override InputParameterModel ToModel(IGqlpInputParameter ast, IMap<TypeKindModel> typeKinds)
  {
    InputBaseModel typeModel = objBase.ToModel(ast.Type, typeKinds);
    return new(new(typeModel, ast.Type.Description)) {
      Modifiers = modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
  }
}
