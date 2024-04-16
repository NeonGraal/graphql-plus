using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Globals;

public class MergeCategoriesTests(
  ITestOutputHelper outputHelper
) : TestAliased<CategoryDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameOutput_ReturnsGood(string category)
    => CanMerge_Good([new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOutput_ReturnsErrors(string name, string category1, string category2)
    => CanMerge_Errors([
      new CategoryDeclAst(AstNulls.At, name, category1),
      new CategoryDeclAst(AstNulls.At, name, category2)],
      category1 == category2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOption_ReturnsErrors(string category)
    => CanMerge_Errors([
      new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Single },
      new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Sequential }]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameOutput_ReturnsExpected(string category)
    => Merge_Expected(
      [new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)],
      new CategoryDeclAst(AstNulls.At, category));

  private readonly MergeCategories _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<CategoryDeclAst> MergerGroups => _merger;

  protected override CategoryDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description, name) { Aliases = aliases };
}
