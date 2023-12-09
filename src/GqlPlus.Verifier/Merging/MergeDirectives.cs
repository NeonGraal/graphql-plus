using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDirectives
  : DescribedMerger<DirectiveDeclAst>
{
  protected override string ItemGroupKey(DirectiveDeclAst item)
    => item.Option.ToString();
}
