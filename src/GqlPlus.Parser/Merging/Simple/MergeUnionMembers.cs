using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeUnionMembers
  : GroupsMerger<IGqlpUnionItem>
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpUnionItem> group)
    => group.Distinct().Count() == 1 ? Messages()
    : group.Last().MakeError("Union Members not unique for " + group.Key);
  protected override string ItemGroupKey(IGqlpUnionItem item)
    => item.Name;
  protected override IGqlpUnionItem MergeGroup(IEnumerable<IGqlpUnionItem> group)
    => group.First();
}
