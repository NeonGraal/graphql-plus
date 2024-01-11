using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal sealed class CategoryModelChecks : ModelAliasedChecks<string, CategoryDeclAst>
{
  protected override CategoryDeclAst NewAst(string input)
    => new(AstNulls.At, input);

  protected override IRendering AstToModel(CategoryDeclAst aliased)
    => aliased.ToModel();
}
