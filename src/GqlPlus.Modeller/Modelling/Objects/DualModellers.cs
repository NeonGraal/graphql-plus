namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  ObjectModellers<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, DualBaseModel, DualFieldModel, ObjAlternateModel> modellers
) : ModellerObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel, DualBaseModel, DualFieldModel, ObjAlternateModel>(TypeKindModel.Dual, modellers)
{
  protected override TypeDualModel ToModel(IGqlpDualObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.ObjParent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.ObjAlternates, typeKinds),
    };
}

internal class DualBaseModeller(
  IModeller<IGqlpObjArg, ObjTypeArgModel> objArg
) : ModellerObjBase<IGqlpDualBase, IGqlpObjArg, DualBaseModel>(objArg)
{
  protected override DualBaseModel ToModel(IGqlpDualBase ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
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
    => new(ast.Name, type with { Description = ast.BaseType.Description }, ast.Description);
}

internal class DualAlternateModeller(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObjAlternate<IGqlpDualBase, IGqlpDualAlternate, DualBaseModel, ObjAlternateModel>(collection, objBase)
{
  protected override ObjAlternateModel AlternateModel(DualBaseModel type)
    => new(type);
}
