using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Globals;

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
