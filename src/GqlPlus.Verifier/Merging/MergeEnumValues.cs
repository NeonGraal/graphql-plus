using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumValues
  : DescribedsMerger<EnumValueAst>
{
  public override EnumValueAst Merge(EnumValueAst[] items)
    => items.First() with { Description = MergeDescriptions(items) };
}
