using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeSchemas : DistinctsMerger<SchemaAst>
{
  public override bool CanMerge(SchemaAst[] items)
    => base.CanMerge(items);

  public override SchemaAst Merge(SchemaAst[] items)
  {
    if (items.Length < 2) {
      return base.Merge(items);
    }

    return items[0];
  }

  protected override string ItemMatchKey(SchemaAst item) => "";
}
