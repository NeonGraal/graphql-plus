using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Token;

namespace GqlPlus.Merging.Globals;

internal class MergeCategories(
  ILoggerFactory logger
) : AstAliasedMerger<CategoryDeclAst>(logger)
{
  public override ITokenMessages CanMerge(IEnumerable<CategoryDeclAst> items)
    => base.CanMerge(items)
      .Add(items.CanMerge(item => item.Option));

  protected override string ItemMatchName => "Output~Modifiers~Option";
  protected override string ItemMatchKey(CategoryDeclAst item)
    => $"{item.Output}~{item.Modifiers.AsString()}~{item.Option}";
}
