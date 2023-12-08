using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDirectives
  : DescribedMerger<DirectiveDeclAst>
{
  public override bool CanMerge(DirectiveDeclAst[] items)
    => items.Select(i => i.Option).Distinct().Count() == 1
    && base.CanMerge(items);
}
