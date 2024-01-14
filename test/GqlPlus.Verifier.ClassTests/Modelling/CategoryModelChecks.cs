using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class CategoryModelChecks : ModelAliasedChecks<string, CategoryDeclAst>
{
  protected override CategoryDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input) { Description = description };

  protected override IRendering AstToModel(CategoryDeclAst aliased)
    => aliased.ToModel();
}
