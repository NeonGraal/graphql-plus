using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Globals;

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModeller<IAstModifier, ModifierModel> modifier
) : ModellerBase<IAstSchemaCategory, CategoryModel>
{
  protected override CategoryModel ToModel(IAstSchemaCategory ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output), ast.Description) {
      Aliases = [.. ast.Aliases],
      Resolution = ast.CategoryOption,
      Modifiers = modifier.ToModels(ast.Modifiers, typeKinds),
    };
}
