using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  IModellerRepository modellers
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
  IModellerRepository modellers
) : ModellerObjField<IAstDualField, DualFieldModel>(modellers)
{
  protected override DualFieldModel FieldModel(IAstDualField ast, ObjBaseModel type, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, type with { Description = ast.Type.Description.IfWhiteSpace() }, ast.Description);
}
