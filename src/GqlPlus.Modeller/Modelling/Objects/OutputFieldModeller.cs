namespace GqlPlus.Modelling.Objects;

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParameter, InputParameterModel> parameter,
  IModeller<IGqlpOutputBase, OutputBaseModel> refBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputBaseModel, OutputFieldModel>(modifier, refBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.Type.EnumMember)
      ? new(field.Name, new(type, field.Type.Description)) {
        Parameters = parameter.ToModels(field.Parameters, typeKinds),
      }
      : new(field.Name, null) { // or should it be `type`
        Enum = new(field.Name, field.Type.Output, field.Type.EnumMember)
      };
}
