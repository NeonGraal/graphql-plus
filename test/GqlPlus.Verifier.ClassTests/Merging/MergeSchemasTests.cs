using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeSchemasTests
  : TestDistinct<SchemaAst>
{
  private readonly MergeSchemas _merger = new();

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItems_ReturnsTrue(string name)
    => CanMerge_True([
      new SchemaAst(AstNulls.At, name),
      new SchemaAst(AstNulls.At, name)]);

  protected override DistinctsMerger<SchemaAst> MergerDistinct => _merger;

  protected override SchemaAst MakeDistinct(string name)
    => new(AstNulls.At, name);
}
