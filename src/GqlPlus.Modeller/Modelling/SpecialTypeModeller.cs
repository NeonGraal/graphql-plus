using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling;

internal class SpecialTypeModeller()
  : ModellerType<IAstTypeSpecial, IAstTypeRef, SpecialTypeModel>(TypeKindModel.Special)
{
  protected override SpecialTypeModel ToModel(IAstTypeSpecial ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Aliases = [.. ast.Aliases],
    };

  internal static SpecialTypeModeller Factory(IModellerRepository _) => new();
}
