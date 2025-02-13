using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeTypeParams
  : GroupsMerger<IGqlpTypeParam>
{
  protected override string ItemGroupKey(IGqlpTypeParam item) => item.Name;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpTypeParam> group)
    => group.CanMergeString(item => item.Description);

  protected override IGqlpTypeParam MergeGroup(IEnumerable<IGqlpTypeParam> group)
  {
    TypeParamAst ast = (TypeParamAst)group.First();
    return ast.MakeDescription(group);
  }
}
