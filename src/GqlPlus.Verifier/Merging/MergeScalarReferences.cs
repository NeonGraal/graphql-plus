using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarReferences
  : GroupsMerger<ScalarReferenceAst>
{
  protected override bool CanMergeGroup(IGrouping<string, ScalarReferenceAst> group)
    => group.Distinct().Count() == 1;

  protected override string ItemGroupKey(ScalarReferenceAst item)
    => item.Name;

  protected override ScalarReferenceAst MergeGroup(IEnumerable<ScalarReferenceAst> group)
    => group.First();
}
