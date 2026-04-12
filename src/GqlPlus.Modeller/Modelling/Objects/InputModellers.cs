namespace GqlPlus.Modelling.Objects;

internal class InputModeller(
  IModellerRepository modellers
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
  IModellerRepository modellers
) : ModellerObjField<IAstInputField, InputFieldModel>(modellers)
{
  private readonly IModeller<IAstConstant, ConstantModel> _constant = modellers.ModellerFor<IAstConstant, ConstantModel>();

  protected override InputFieldModel FieldModel(IAstInputField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.Type.Description.IfWhiteSpace() }, ast.Description) {
      Default = _constant.TryModel(ast.DefaultValue, typeKinds),
    };
}

internal class InputParamModeller(
  IModellerRepository modellers
) : ModellerBase<IAstInputParam, InputParamModel>
{
  private readonly IModifierModeller _modifier = modellers.ModifierModeller;
  private readonly IModeller<IAstConstant, ConstantModel> _constant = modellers.ModellerFor<IAstConstant, ConstantModel>();

  protected override InputParamModel ToModel(IAstInputParam ast, IMap<TypeKindModel> typeKinds)
  {
    InputParamModel model = new(ast.Type.Name, ast.Description) {
      IsTypeParam = ast.Type.IsTypeParam,
      Modifiers = _modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = _constant.TryModel(ast.DefaultValue, typeKinds),
    };
    return model;
  }
}
