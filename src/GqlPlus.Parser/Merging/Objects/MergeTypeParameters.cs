using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Merging.Objects;

internal class MergeTypeParams
  : GroupsMerger<IGqlpTypeParam>
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpTypeParam> group)
    => TokenMessages.New;
  protected override string ItemGroupKey(IGqlpTypeParam item) => item.Name;

  protected override IGqlpTypeParam MergeGroup(IEnumerable<IGqlpTypeParam> group)
  {
    TypeParamAst ast = (TypeParamAst)group.First();
    return ast.MakeDescription(group);
  }
}
