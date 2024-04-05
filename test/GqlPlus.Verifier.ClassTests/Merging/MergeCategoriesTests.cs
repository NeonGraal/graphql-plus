using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeCategoriesTests(
  ITestOutputHelper outputHelper
) : TestAliased<CategoryDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameOutput_ReturnsTrue(string category)
    => CanMerge_True([new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOutput_ReturnsFalse(string name, string category1, string category2)
    => CanMerge_False([
      new CategoryDeclAst(AstNulls.At, name, category1),
      new CategoryDeclAst(AstNulls.At, name, category2)],
      category1 == category2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentOption_ReturnsFalse(string category)
    => CanMerge_False([
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
