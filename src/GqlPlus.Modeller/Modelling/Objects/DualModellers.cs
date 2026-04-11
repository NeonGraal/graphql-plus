using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  ObjectModellers<IAstDualField, DualFieldModel> modellers
) : ModellerObject<IAstObject<IAstDualField>, IAstDualField, TypeDualModel, DualFieldModel>(TypeKindModel.Dual, modellers)
{
  protected override TypeDualModel ToModel(IAstObject<IAstDualField> ast, IMap<TypeKindModel> typeKinds)
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
  IModeller<IAstObjBase, ObjBaseModel> objBase
) : ModellerObjField<IAstDualField, DualFieldModel>(modifier, objBase)
{
  protected override DualFieldModel FieldModel(IAstDualField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.Type.Description.IfWhiteSpace() }, ast.Description);
}
