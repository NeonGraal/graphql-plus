using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeDirectives(
  ILoggerFactory logger,
  IMerge<IGqlpInputParam> parameters
) : AstAliasedMerger<IGqlpSchemaDirective>(logger)
{
  protected override string ItemMatchName => "Option";
  protected override string ItemMatchKey(IGqlpSchemaDirective item)
    => item.DirectiveOption.ToString();

  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpSchemaDirective> group)
    => base.CanMergeGroup(group)
     .Add(group.CanMerge(item => item.Parameter, parameters));

  protected override IGqlpSchemaDirective MergeGroup(IEnumerable<IGqlpSchemaDirective> group)
  {
    DirectiveDeclAst ast = (DirectiveDeclAst)base.MergeGroup(group);
    return ast with {
      Parameter = group.Merge(item => item.Parameter, parameters).FirstOrDefault(),
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
  }
}
