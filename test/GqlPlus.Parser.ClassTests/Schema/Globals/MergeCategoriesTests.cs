using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Schema.Globals;

public class MergeCategoriesTests(
  ITestOutputHelper outputHelper
) : TestAliased<IGqlpSchemaCategory>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameOutput_ReturnsGood(string category)
    => CanMerge_Good([new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOutput_ReturnsErrors(string name, string category1, string category2)
    => this
      .SkipIf(category1 == category2)
      .CanMerge_Errors(
        new CategoryDeclAst(AstNulls.At, name, category1),
        new CategoryDeclAst(AstNulls.At, name, category2));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentOption_ReturnsErrors(string category)
    => CanMerge_Errors([
      new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Single },
      new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Sequential }]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSameOutput_ReturnsExpected(string category)
    => Merge_Expected(
      [new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)],
      new CategoryDeclAst(AstNulls.At, category));

  private readonly MergeCategories _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpSchemaCategory> MergerGroups => _merger;

  protected override IGqlpSchemaCategory MakeAliased(string name, string[]? aliases = null, string description = "")
    => new CategoryDeclAst(AstNulls.At, name, description, name) { Aliases = aliases ?? [] };
}
