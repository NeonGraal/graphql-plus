using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeCategories(
  ILoggerFactory logger
) : AstAliasedMerger<CategoryDeclAst>(logger)
{
  public override bool CanMerge(IEnumerable<CategoryDeclAst> items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Option);

  protected override string ItemMatchKey(CategoryDeclAst item)
    => $"{item.Output}{item.Modifiers.AsString()}~{item.Option}";
}
