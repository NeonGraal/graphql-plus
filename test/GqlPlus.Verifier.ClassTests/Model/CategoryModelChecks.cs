using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class CategoryModelChecks : ModelAliasedChecks<CategoryDeclAst>
{
  protected override CategoryDeclAst NewAliasedAst(string input)
    => new(AstNulls.At, input);

  protected override IRendering AstToModel(CategoryDeclAst aliased)
    => aliased.ToModel();

  internal void Category_Expected(CategoryDeclAst category, string expected)
    => Model_Expected(category.ToModel(), expected);
}
