using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeUnionMembers
  : GroupsMerger<IAstUnionMember>
{
  protected override IMessages CanMergeGroup(IGrouping<string, IAstUnionMember> group)
    => group.Distinct().Count() == 1 ? Messages.New
    : group.Last().MakeError("Union Members not unique for " + group.Key);
  protected override string ItemGroupKey(IAstUnionMember item)
    => item.Name;
  protected override IAstUnionMember MergeGroup(IEnumerable<IAstUnionMember> group)
    => group.First();
}
