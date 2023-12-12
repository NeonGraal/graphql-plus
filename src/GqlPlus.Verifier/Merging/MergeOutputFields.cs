using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOutputFields(IMerge<ParameterAst> parameters)
  : FieldsMerger<OutputFieldAst, OutputReferenceAst>
{
  public override bool CanMerge(OutputFieldAst[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.EnumValue ?? "-")
      && parameters.CanMerge([.. items.SelectMany(item => item.Parameters)]);
}
