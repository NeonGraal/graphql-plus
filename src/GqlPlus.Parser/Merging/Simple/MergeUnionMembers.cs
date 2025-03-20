using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Merging.Simple;

internal class MergeUnionMembers
  : GroupsMerger<IGqlpUnionItem>
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpUnionItem> group)
    => group.Distinct().Count() == 1 ? TokenMessages.New
    : group.Last().MakeError("Union Members not unique for " + group.Key);
  protected override string ItemGroupKey(IGqlpUnionItem item)
    => item.Name;
  protected override IGqlpUnionItem MergeGroup(IEnumerable<IGqlpUnionItem> group)
    => group.First();
}
