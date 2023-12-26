using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeCategoriesTests
  : TestAliased<CategoryDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameOutput_ReturnsTrue(string category)
    => CanMerge_True([new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOutput_ReturnsFalse(string name, string category1, string category2)
    => CanMerge_False([
      new CategoryDeclAst(AstNulls.At, name, category1),
      new CategoryDeclAst(AstNulls.At, name, category2)],
      category1 == category2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOption_ReturnsFalse(string category)
    => CanMerge_False([
      new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Single },
      new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Sequential }]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsSameOutput_ReturnsExpected(string category)
    => Merge_Expected(
      [new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category)],
      new CategoryDeclAst(AstNulls.At, category));

  private readonly MergeCategories _merger = new();

  protected override GroupsMerger<CategoryDeclAst> MergerGroups => _merger;

  protected override CategoryDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description, name) { Aliases = aliases };
}
