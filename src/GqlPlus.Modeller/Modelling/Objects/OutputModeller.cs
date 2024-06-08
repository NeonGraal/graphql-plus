namespace GqlPlus.Modelling.Objects;

internal class OutputModeller(
  IAlternateModeller<IGqlpOutputBase, OutputBaseModel> alternate,
  IModeller<IGqlpOutputField, OutputFieldModel> objField,
  IModeller<IGqlpOutputBase, OutputBaseModel> objBase
) : ModellerObject<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, TypeOutputModel, OutputBaseModel, OutputFieldModel>(TypeKindModel.Output, alternate, objField, objBase)
{
  protected override TypeOutputModel ToModel(IGqlpOutputObject ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ParentModel(ast.Parent, typeKinds),
      TypeParameters = TypeParametersModels(ast.TypeParameters),
      Fields = FieldsModels(ast.Fields, typeKinds),
      Alternates = AlternatesModels(ast.Alternates, typeKinds),
    };
}
