using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class CategoryMerger
  : IMerge<CategoryDeclAst>
{
  public bool CanMerge(CategoryDeclAst[] items)
    => items.Select(i => i.Output).Distinct().Count() == 1;

  public CategoryDeclAst Merge(CategoryDeclAst[] items) => throw new NotImplementedException();
}
