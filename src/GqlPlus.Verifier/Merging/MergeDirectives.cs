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
      && items.ManyGroupCanMerge(d => d.Parameters, p => p.Type.FullType, parameters);

  protected override DirectiveDeclAst MergeGroup(DirectiveDeclAst[] items)
    => items.First() with { Description = items.MergeDescriptions() };
}
