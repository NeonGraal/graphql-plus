using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeTypeParams
  : GroupsMerger<IGqlpTypeParam>
{
  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpTypeParam> group)
    => group.CanMergeString(p => p.Constraint);

  protected override string ItemGroupKey(IGqlpTypeParam item) => item.Name;

  protected override IGqlpTypeParam MergeGroup(IEnumerable<IGqlpTypeParam> group)
  {
    IGqlpTypeParam[] asts = [.. group];
    TypeParamAst ast = (TypeParamAst)asts.First();
    string[] constraint = [.. asts
      .Select(p => p.Constraint)
      .Where(c => !c.IsWhiteSpace())
      .Distinct()];

    if (constraint.Length > 1) {
      throw new InvalidOperationException($"Type parameter '{ast.Name}' has multiple constraints: {string.Join(", ", constraint)}");
    } else if (constraint.Length == 1) {
      ast = ast with { Constraint = constraint[0] };
    }

    return ast.MakeDescription(asts);
  }
}
