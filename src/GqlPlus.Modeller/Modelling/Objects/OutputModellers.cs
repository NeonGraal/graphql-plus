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
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class OutputBaseModeller(
  IModeller<IGqlpDualBase, DualBaseModel> dual
) : ModellerObjBase<IGqlpOutputBase, OutputBaseModel, OutputArgumentModel>
{
  internal override OutputArgumentModel NewArgument(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(ast.EnumMember)
      ? new(ast.Output) { Ref = ToModel(ast, typeKinds) }
      : new(ast.Output) { EnumMember = ast.EnumMember };

  protected override OutputBaseModel ToModel(IGqlpOutputBase ast, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(ast.Output, out TypeKindModel typeKind) && typeKind == TypeKindModel.Dual
    ? new(ast.Output) {
      Dual = dual.ToModel(ast.ToDual, typeKinds)
    }
    : new(ast.Output) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class OutputFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpInputParameter, InputParameterModel> parameter,
  IModeller<IGqlpOutputBase, OutputBaseModel> refBase
) : ModellerObjField<IGqlpOutputBase, IGqlpOutputField, OutputBaseModel, OutputFieldModel>(modifier, refBase)
{
  protected override OutputFieldModel FieldModel(IGqlpOutputField field, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(field.BaseType.EnumMember)
      ? new(field.Name, new(type, field.Type.Description)) {
        Parameters = parameter.ToModels(field.Parameters, typeKinds),
      }
      : new(field.Name, null) { // or should it be `type`
        Enum = new(field.Name, field.BaseType.Output, field.BaseType.EnumMember)
      };
}

internal class OutputAlternateModeller(
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjAlternate<IGqlpOutputBase, IGqlpOutputAlternate, OutputBaseModel, OutputAlternateModel>(objBase, collection)
{
  protected override OutputAlternateModel AlternateModel(IGqlpOutputAlternate ast, OutputBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(new(type, ast.Type.Description));
}
