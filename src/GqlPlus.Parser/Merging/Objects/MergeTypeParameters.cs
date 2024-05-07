using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeTypeParameters
  : GroupsMerger<IGqlpTypeParameter>
{
  protected override string ItemGroupKey(IGqlpTypeParameter item) => item.Name;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpTypeParameter> group)
    => group.CanMergeString(item => item.Description);

  protected override TypeParameterAst MergeGroup(IEnumerable<IGqlpTypeParameter> group)
  {
    TypeParameterAst ast = (TypeParameterAst)group.First();
    return ast with { Description = group.MergeDescriptions() };
  }
}
