using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDirectives(
  IMerge<ParameterAst> parameters
) : AliasedMerger<DirectiveDeclAst>
{
  protected override string ItemMatchKey(DirectiveDeclAst item)
    => item.Option.ToString();

  public override bool CanMerge(IEnumerable<DirectiveDeclAst> items)
    => base.CanMerge(items)
      && items.ManyCanMerge(d => d.Parameters, parameters);

  protected override DirectiveDeclAst MergeGroup(IEnumerable<DirectiveDeclAst> group)
    => base.MergeGroup(group) with {
      Parameters = [.. group.ManyMerge(item => item.Parameters, parameters)],
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
}
