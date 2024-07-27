namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  IModeller<IGqlpOutputAlternate, OutputAlternateModel> alternate,
  IModeller<IGqlpOutputField, OutputFieldModel> objField,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>(TypeKindModel.Output, alternate, objField, objBase)
{
  protected override TypeOutputModel ToModel(IGqlpOutputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class OutputArgModeller(
  IModeller<IGqlpDualArg, DualArgModel> dual
) : ModellerObjArg<IGqlpOutputArg, OutputArgModel>
{
  protected override OutputArgModel ToModel(IGqlpOutputArg ast, IMap<TypeKindModel> typeKinds)
      => string.IsNullOrWhiteSpace(ast.EnumMember)
      ? typeKinds.TryGetValue(ast.Output, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
        ? new("") {
          Dual = dual.ToModel(ast.ToDual, typeKinds)
        }
        : new(ast.Output) {
          IsTypeParam = ast.IsTypeParam,
        }
      : new(ast.Output) { EnumMember = ast.EnumMember };
}

internal class OutputBaseModeller(
  IModeller<IGqlpOutputArg, OutputArgModel> objArg,
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpOutputBase, IGqlpOutputArg, OutputBaseModel, OutputArgModel>(objArg)
{
  protected override OutputBaseModel ToModel(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Output, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new("") {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Output) {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParam, InputParamModel> parameter,
  IModeller<IGqlpOutputBase, OutputBaseModel> refBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputBaseModel, OutputFieldModel>(modifier, refBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.BaseType.EnumMember)
      ? new(field.Name, new(type, field.Type.Description)) {
        Params = parameter.ToModels(field.Params, typeKinds),
      }
      : new(field.Name, null) { // or should it be `type`
        Enum = new(field.Name, field.BaseType.TypeName, field.BaseType.EnumMember)
      };
}

internal class OutputAlternateModeller(
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjAlternate<IGqlpOutputBase, IGqlpOutputAlternate, OutputBaseModel, OutputAlternateModel>(objBase, collection)
{
  protected override OutputAlternateModel AlternateModel(IGqlpOutputAlternate ast, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(new ObjDescribedModel<OutputBaseModel>(type, ast.Type.Description));
}
