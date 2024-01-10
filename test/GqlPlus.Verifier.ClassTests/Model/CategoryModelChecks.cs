using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class CategoryModelChecks : ModelBaseChecks<CategoryModel>
{
  internal void Category_Expected(CategoryDeclAst category, string expected)
    => Model_Expected(category.ToModel(), expected);
}
