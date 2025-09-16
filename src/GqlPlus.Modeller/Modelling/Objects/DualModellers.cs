namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  ObjectModellers<IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, DualFieldModel> modellers
) : ModellerObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel, DualFieldModel>(TypeKindModel.Dual, modellers)
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

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpDualBase, ObjBaseModel> objBase
) : ModellerObjField<IGqlpDualBase, IGqlpDualField, DualFieldModel>(modifier, objBase)
{
  protected override DualFieldModel FieldModel(IGqlpDualField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.BaseType.Description }, ast.Description);
}
