namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  ObjectModellers<IAstOutputField, OutputFieldModel> modellers
) : ModellerObject<IAstObject<IAstOutputField>, IAstOutputField, TypeOutputModel, OutputFieldModel>(TypeKindModel.Output, modellers)
{
  protected override TypeOutputModel ToModel(IAstObject<IAstOutputField> ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  // IModeller<IAstEnumValue, EnumValueModel> enumValue,
  IModeller<IAstInputParam, InputParamModel> parameter,
  IModeller<IAstObjBase, ObjBaseModel> objBase
) : ModellerObjField<IAstOutputField, OutputFieldModel>(modifier, objBase)
{
  protected override OutputFieldModel FieldModel(IAstOutputField field, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => field.EnumValue is null
      ? new(field.Name, type, field.Description) {
        Parameter = parameter.TryModel(field.Parameter, typeKinds),
      }
      : new(field.Name, type, field.Description) {
        Enum = new(field.Name, type.Name, field.EnumValue.EnumLabel, type.Description)
      };
}
