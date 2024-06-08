namespace GqlPlus.Modelling.Objects;

internal class DualModeller(
  IAlternateModeller<IGqlpDualBase, DualBaseModel> alternate,
  IModeller<IGqlpDualField, DualFieldModel> objField,
  IModeller<IGqlpDualBase, DualBaseModel> objBase
) : ModellerObject<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, TypeDualModel, DualBaseModel, DualFieldModel>(TypeKindModel.Dual, alternate, objField, objBase)
{
  protected override TypeDualModel ToModel(IGqlpDualObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}
