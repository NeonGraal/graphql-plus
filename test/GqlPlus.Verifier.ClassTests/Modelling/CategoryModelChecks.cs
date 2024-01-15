using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class CategoryModelChecks
  : ModelAliasedChecks<string, CategoryDeclAst>
{
  internal readonly IModeller<CategoryDeclAst> Category;
  internal readonly IModeller<ModifierAst> Modifier;

  public CategoryModelChecks()
    => Category = new CategoryModeller(
      Modifier = ForModeller<ModifierAst, ModifierModel>(
        m => new(m.Kind)));

  protected override CategoryDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input) { Description = description };

  protected override IRendering AstToModel(CategoryDeclAst aliased)
    => Category.ToRenderer(aliased);
}
