using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Globals;

internal class MergeDirectives(
  ILoggerFactory logger,
  IMerge<InputParameterAst> parameters
) : AstAliasedMerger<IGqlpSchemaDirective>(logger)
{
  protected override string ItemMatchName => "Option";
  protected override string ItemMatchKey(IGqlpSchemaDirective item)
    => item.DirectiveOption.ToString();

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpSchemaDirective> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyCanMerge(d => d.Parameters.ArrayOf<InputParameterAst>(), parameters));

  protected override IGqlpSchemaDirective MergeGroup(IEnumerable<IGqlpSchemaDirective> group)
  {
    DirectiveDeclAst ast = (DirectiveDeclAst)base.MergeGroup(group);
    return ast with {
      Parameters = [.. group.ManyMerge(item => item.Parameters.ArrayOf<InputParameterAst>(), parameters)],
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
  }
}
