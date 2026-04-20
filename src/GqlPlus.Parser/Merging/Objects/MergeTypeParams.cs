using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeTypeParams
  : GroupsMerger<IAstTypeParam>
{
  protected override IMessages CanMergeGroup(IGrouping<string, IAstTypeParam> group)
    => group.CanMergeString(p => p.Constraint);

  protected override string ItemGroupKey(IAstTypeParam item) => item.Name;

  protected override IAstTypeParam MergeGroup(IEnumerable<IAstTypeParam> group)
  {
    IAstTypeParam[] asts = [.. group];
    TypeParamAst ast = (TypeParamAst)asts.First();
    string[] constraint = [.. asts
      .Select(p => p.Constraint)
      .RemoveEmpty()
      .Distinct()];

    if (constraint.Length > 1) {
      throw new InvalidOperationException($"Type parameter '{ast.Name}' has multiple constraints: {constraint.Joined(", ")}");
    } else if (constraint.Length == 1) {
      ast = ast with { Constraint = constraint[0] };
    }

    return ast.MakeDescription(asts);
  }

  internal static MergeTypeParams Factory(IMergerRepository _) => new();
}
