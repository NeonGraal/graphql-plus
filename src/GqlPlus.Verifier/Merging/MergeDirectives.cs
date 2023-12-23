using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDirectives(
  IMerge<ParameterAst> parameters
) : NamedMerger<DirectiveDeclAst>
{
  protected override string ItemMatchKey(DirectiveDeclAst item)
    => item.Option.ToString();

  public override bool CanMerge(DirectiveDeclAst[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Description)
      && items.ManyCanMerge(d => d.Parameters, parameters);

  protected override DirectiveDeclAst MergeGroup(DirectiveDeclAst[] items)
    => items.First() with {
      Description = items.MergeDescriptions(),
      Parameters = items.ManyMerge(item => item.Parameters, parameters),
      Locations = items.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
}
