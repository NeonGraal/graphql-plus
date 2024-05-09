using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeDirectives(
  ILoggerFactory logger,
  IMerge<InputParameterAst> parameters
) : AstAliasedMerger<IGqlpSchemaDirective>(logger)
{
  protected override string ItemMatchName => "Option";
  protected override string ItemMatchKey(IGqlpSchemaDirective item)
    => item.DirectiveOption.ToString();

  public override ITokenMessages CanMerge(IEnumerable<IGqlpSchemaDirective> items)
    => base.CanMerge(items)
      .Add(items.ManyCanMerge(d => d.Parameters.ArrayOf<InputParameterAst>(), parameters));

  protected override IGqlpSchemaDirective MergeGroup(IEnumerable<IGqlpSchemaDirective> group)
  {
    DirectiveDeclAst ast = (DirectiveDeclAst)base.MergeGroup(group);
    return ast with {
      Parameters = [.. group.ManyMerge(item => item.Parameters.ArrayOf<InputParameterAst>(), parameters)],
      Locations = group.Aggregate(DirectiveLocation.None, (l, d) => d.Locations | l),
    };
  }
}
