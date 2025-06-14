namespace GqlPlus.Modelling;

internal class SpecialTypeModeller()
  : ModellerType<IGqlpTypeSpecial, IGqlpTypeRef, SpecialTypeModel>(TypeKindModel.Special)
{
  protected override SpecialTypeModel ToModel(IGqlpTypeSpecial ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
    };
}
