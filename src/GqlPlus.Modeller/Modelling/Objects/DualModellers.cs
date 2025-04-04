namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  IModeller<IGqlpDualAlternate, DualAlternateModel> objAlt,
  IModeller<IGqlpDualField, DualFieldModel> objField,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>(TypeKindModel.Dual, objAlt, objField, objBase)
{
  protected override TypeDualModel ToModel(IGqlpDualObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class DualArgModeller
  : ModellerObjArg<IGqlpDualArg, DualArgModel>
{
  protected override DualArgModel ToModel(IGqlpDualArg ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Dual, ast.Description) {
      IsTypeParam = ast.IsTypeParam,
    };
}

internal class DualBaseModeller(
  IModeller<IGqlpDualArg, DualArgModel> objArg
) : ModellerObjBase<IGqlpDualBase, IGqlpDualArg, DualBaseModel, DualArgModel>(objArg)
{
  protected override DualBaseModel ToModel(IGqlpDualBase ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Dual, ast.Description) {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
    };
}

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObjField<IGqlpDualBase, IGqlpDualField, DualBaseModel, DualFieldModel>(modifier, objBase)
{
  protected override DualFieldModel FieldModel(IGqlpDualField ast, DualBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.Type.Description }, ast.Description);
}

internal class DualAlternateModeller(
  IModeller<IGqlpDualArg, DualArgModel> objArg,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjAlternate<IGqlpDualArg, IGqlpDualAlternate, DualArgModel, DualAlternateModel>(objArg, collection)
{
  protected override DualAlternateModel AlternateModel(IGqlpDualAlternate ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description);
}
