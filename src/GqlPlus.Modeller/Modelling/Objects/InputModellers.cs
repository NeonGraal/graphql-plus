using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

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

internal class InputBaseModeller(
  IModeller<IGqlpObjArg, ObjTypeArgModel> objArg
) : ModellerObjBase<IGqlpInputBase, IGqlpObjArg, InputBaseModel>(objArg)
{
  protected override InputBaseModel ToModel(IGqlpInputBase ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
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
