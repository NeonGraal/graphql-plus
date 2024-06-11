namespace GqlPlus.Modelling;

internal class SpecialTypeModeller()
  : ModellerType<IGqlpTypeSpecial, string, SpecialTypeModel>(TypeKindModel.Special)
{
  protected override SpecialTypeModel ToModel(IGqlpTypeSpecial ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
    };
}
