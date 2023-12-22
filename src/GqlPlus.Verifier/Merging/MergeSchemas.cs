using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeSchemas
  : GroupsMerger<SchemaAst>
{
  protected override string ItemGroupKey(SchemaAst item)
    => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, SchemaAst> group)
    => true;

  protected override SchemaAst MergeGroup(SchemaAst[] items)
    => items.First();
}
