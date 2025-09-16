using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  ObjectModellers<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, OutputFieldModel> modellers
) : ModellerObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel, OutputFieldModel>(TypeKindModel.Output, modellers)
{
  protected override TypeOutputModel ToModel(IGqlpOutputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParam, InputParamModel> parameter,
  IModeller<IGqlpOutputBase, ObjBaseModel> objBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputFieldModel>(modifier, objBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.EnumLabel)
      ? new(field.Name, type, field.Description) {
        Params = parameter.ToModels(field.Params, typeKinds),
      }
      : new(field.Name, type, field.Description) {
        Enum = new(field.Name, type.Name, field.EnumLabel!, type.Description)
      };
}
