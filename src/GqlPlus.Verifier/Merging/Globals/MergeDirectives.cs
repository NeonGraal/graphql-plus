using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeDirectives(
  ILoggerFactory logger,
  IMerge<ParameterAst> parameters
) : AstAliasedMerger<DirectiveDeclAst>(logger)
{
  protected override string ItemMatchName => "Option";
  protected override string ItemMatchKey(DirectiveDeclAst item)
    => item.Option.ToString();

  public override ITokenMessages CanMerge(IEnumerable<DirectiveDeclAst> items)
    => base.CanMerge(items)
      .Add(items.ManyCanMerge(d => d.Parameters, parameters));

  protected override DirectiveDeclAst MergeGroup(IEnumerable<DirectiveDeclAst> group)
    => base.MergeGroup(group) with {
      Parameters = [.. group.ManyMerge(item => item.Parameters, parameters)],
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
}
