using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums
  : DescribedMerger<EnumDeclAst>
{
  public override bool CanMerge(EnumDeclAst[] items)
    => items.Select(i => i.Extends ?? "").Distinct().Count() == 1 && base.CanMerge(items);
}
