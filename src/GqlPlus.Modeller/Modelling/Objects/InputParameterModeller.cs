namespace GqlPlus.Modelling.Objects;

internal class InputParameterModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> objBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpInputParameter, InputParameterModel>
{
  protected override InputParameterModel ToModel(IGqlpInputParameter ast, IMap<TypeKindModel> typeKinds)
  {
    InputBaseModel typeModel = objBase.ToModel(ast.Type, typeKinds);
    return new(new(typeModel) { Description = ast.Type.Description }) {
      Modifiers = modifier.ToModels<ModifierModel>(ast.Modifiers, typeKinds),
      DefaultValue = constant.TryModel(ast.DefaultValue, typeKinds),
    };
  }
}
