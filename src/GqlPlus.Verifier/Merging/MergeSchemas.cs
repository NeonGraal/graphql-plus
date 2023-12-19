using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeSchemas : DistinctsMerger<SchemaAst>
{
  public override SchemaAst Merge(SchemaAst[] items)
    => items.First();
}
