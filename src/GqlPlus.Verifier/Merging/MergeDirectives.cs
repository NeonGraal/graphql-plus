using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDirectives(
  IMerge<ParameterAst> parameters
) : DescribedsMerger<DirectiveDeclAst>
{
  protected override string ItemMatchKey(DirectiveDeclAst item)
    => item.Option.ToString();

  public override bool CanMerge(DirectiveDeclAst[] items)
  {
    return base.CanMerge(items)
        && items.ManyGroupMerge(d => d.Parameters, p => p.Type.FullType, parameters);
  }
}
