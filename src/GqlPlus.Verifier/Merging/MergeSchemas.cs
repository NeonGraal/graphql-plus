using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeSchemas : DistinctsMerger<SchemaAst>
{
  protected override string ItemMatchKey(SchemaAst item) => "";
}
