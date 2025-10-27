namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  ObjectModellers<IGqlpDualField, DualFieldModel> modellers
) : ModellerObject<IGqlpObject<IGqlpDualField>, IGqlpDualField, TypeDualModel, DualFieldModel>(TypeKindModel.Dual, modellers)
{
  protected override TypeDualModel ToModel(IGqlpObject<IGqlpDualField> ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParams = TypeParamsModels(ast.TypeParams, typeKinds),
      Fields = FieldsModels(ast.ObjFields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}

internal class DualFieldModeller(
  IModifierModeller modifier,
  IModeller<IGqlpObjBase, ObjBaseModel> objBase
) : ModellerObjField<IGqlpDualField, DualFieldModel>(modifier, objBase)
{
  protected override DualFieldModel FieldModel(IGqlpDualField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.Type.Description.IfWhiteSpace() }, ast.Description);
}
