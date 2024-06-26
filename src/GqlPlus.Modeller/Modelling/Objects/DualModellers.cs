namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  IModeller<IGqlpDualAlternate, DualAlternateModel> objAlt,
  IModeller<IGqlpDualField, DualFieldModel> objField,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, objAlt, objField, objBase)
{
  protected override TypeDualModel ToModel(IGqlpDualObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class DualBaseModeller
  : ModellerObjBase<IGqlpDualBase, DualBaseModel>
{
  protected override DualBaseModel ToModel(IGqlpDualBase ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Dual) {
      IsTypeParameter = ast.IsTypeParameter,
      Arguments = ModelArguments(ast, typeKinds),
    };
}

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObjField<IGqlpDualBase, IGqlpDualField, DualBaseModel, DualFieldModel>(modifier, objBase)
{
  protected override DualFieldModel FieldModel(IGqlpDualField ast, DualBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, new(type, ast.Type.Description));
}

internal class DualAlternateModeller(
  IModeller<IGqlpDualBase, DualBaseModel> objBase,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjAlternate<IGqlpDualBase, IGqlpDualAlternate, DualBaseModel, DualAlternateModel>(objBase, collection)
{
  protected override DualAlternateModel AlternateModel(IGqlpDualAlternate ast, DualBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(new(type, ast.Type.Description));
}
