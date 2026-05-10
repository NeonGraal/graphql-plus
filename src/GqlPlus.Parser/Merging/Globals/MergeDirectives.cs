using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeDirectives(
  IMergerRepository mergers
) : AstAliasedMerger<IAstSchemaDirective>(mergers)
{
  private readonly DeferOne<IMerge<IAstInputParam>> _inputParam = mergers.MergerFor<IAstInputParam>();

  protected override string ItemMatchName => "Option";
  protected override string ItemMatchKey(IAstSchemaDirective item)
    => item.DirectiveOption.ToString();

  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchemaDirective> group)
    => base.CanMergeGroup(group)
     .Add(group.CanMerge(item => item.Parameter, _inputParam.I));

  protected override IAstSchemaDirective MergeGroup(IEnumerable<IAstSchemaDirective> group)
  {
    DirectiveDeclAst ast = (DirectiveDeclAst)base.MergeGroup(group);
    return ast with {
      Parameter = group.Merge(item => item.Parameter, _inputParam.I).FirstOrDefault(),
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
  }

  internal static MergeDirectives Factory(IMergerRepository m) => new(m);
}
