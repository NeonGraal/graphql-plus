namespace GqlPlus.Modelling.Objects;

internal class InputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputBase, InputBaseModel> refBase,
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerObjField<IGqlpInputBase, IGqlpInputField, InputBaseModel, InputFieldModel>(modifier, refBase)
{
  protected override InputFieldModel FieldModel(IGqlpInputField ast, InputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type) {
      Default = constant.TryModel(ast.DefaultValue, typeKinds),
    };
}
