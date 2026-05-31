using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Merging.Schema.Globals;

public class MergeOperationsTests
  : TestAliasedMerger<IAstSchemaOperation, OperationInput>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameCategory_ReturnsGood(OperationInput input)
    => CanMerge_Good([
      new OperationDeclAst(AstNulls.At, input.Name, input.Category),
      new OperationDeclAst(AstNulls.At, input.Name, input.Category)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOption_ReturnsErrors(OperationInput input, string category2)
    => this
    .SkipEqual(input.Category, category2)
    .CanMerge_Errors([
      new OperationDeclAst(AstNulls.At, input.Name, input.Category),
      new OperationDeclAst(AstNulls.At, input.Name, category2)]);

  private readonly MergeOperations _merger;

  public MergeOperationsTests()
  {
    IMergerRepository mergers = Substitute.For<IMergerRepository>();
    _merger = new(mergers);
  }

  internal override GroupsMerger<IAstSchemaOperation> MergerGroups => _merger;

  protected override IAstSchemaOperation MakeAliased(OperationInput input, string[]? aliases = null, string description = "")
    => new OperationDeclAst(AstNulls.At, input.Name, description, input.Category) { Aliases = aliases ?? [] };

  protected override bool InputEquals(OperationInput input1, OperationInput input2)
    => string.Equals(input1.Name, input2.Name, StringComparison.Ordinal);
}
