using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Globals;

internal class MergeDirectives(
  ILoggerFactory logger,
  IMerge<IGqlpInputParam> parameters
) : AstAliasedMerger<IGqlpSchemaDirective>(logger)
{
  protected override string ItemMatchName => "Option";
  protected override string ItemMatchKey(IGqlpSchemaDirective item)
    => item.DirectiveOption.ToString();

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpSchemaDirective> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyCanMerge(d => d.Params, parameters));

  protected override IGqlpSchemaDirective MergeGroup(IEnumerable<IGqlpSchemaDirective> group)
  {
    DirectiveDeclAst ast = (DirectiveDeclAst)base.MergeGroup(group);
    return ast with {
      Params = group.ManyMerge(item => item.Params, parameters).ArrayOf<InputParamAst>(),
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
  }
}
