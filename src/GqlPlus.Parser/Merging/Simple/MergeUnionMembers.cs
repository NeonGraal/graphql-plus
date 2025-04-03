using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Merging.Simple;

internal class MergeUnionMembers
  : GroupsMerger<IGqlpUnionMember>
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpUnionMember> group)
    => group.Distinct().Count() == 1 ? TokenMessages.New
    : group.Last().MakeError("Union Members not unique for " + group.Key);
  protected override string ItemGroupKey(IGqlpUnionMember item)
    => item.Name;
  protected override IGqlpUnionMember MergeGroup(IEnumerable<IGqlpUnionMember> group)
    => group.First();
}
