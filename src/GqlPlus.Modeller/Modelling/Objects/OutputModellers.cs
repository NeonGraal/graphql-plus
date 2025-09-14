using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  ObjectModellers<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, OutputBaseModel, OutputFieldModel, OutputAlternateModel> modellers
) : ModellerObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, modellers)
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

internal class OutputBaseModeller(
  IModeller<IGqlpObjArg, ObjTypeArgModel> objArg,
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpOutputBase, IGqlpObjArg, OutputBaseModel, ObjTypeArgModel>(objArg)
{
  protected override OutputBaseModel ToModel(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new("", ast.Description) {
      IsTypeParam = ast.IsTypeParam,
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Name, ast.Description) {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParam, InputParamModel> parameter,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputBaseModel, OutputFieldModel>(modifier, objBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.EnumLabel)
      ? new(field.Name, type, field.Description) {
        Params = parameter.ToModels(field.Params, typeKinds),
      }
      : new(field.Name, type, field.Description) {
        Enum = new(field.Name, type.Name, field.EnumLabel!, type.Description)
      };
}

internal class OutputAlternateModeller(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObjAlternate<IGqlpOutputBase, IGqlpOutputAlternate, OutputBaseModel, OutputAlternateModel>(collection, objBase)
{
  protected override OutputAlternateModel AlternateModel(OutputBaseModel type)
    => new(type);
}
