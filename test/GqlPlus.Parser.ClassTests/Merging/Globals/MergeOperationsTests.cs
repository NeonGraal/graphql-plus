using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Globals;

public class MergeOperationsTests(
  ITestOutputHelper outputHelper
) : TestAliased<IGqlpSchemaOperation, OperationInput>
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

  private readonly MergeOperations _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpSchemaOperation> MergerGroups => _merger;

  protected override IGqlpSchemaOperation MakeAliased(OperationInput input, string[]? aliases = null, string description = "")
    => new OperationDeclAst(AstNulls.At, input.Name, description, input.Category) { Aliases = aliases ?? [] };

  protected override string GetName(OperationInput input)
    => input.Name;
}
