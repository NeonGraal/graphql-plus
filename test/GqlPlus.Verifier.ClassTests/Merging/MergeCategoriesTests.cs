using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeCategoriesTests
  : TestDescriptions<CategoryDeclAst>
{
  private readonly MergeCategories _merger = new();

  protected override DescribedsMerger<CategoryDeclAst> MergerDescribed => _merger;

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameOutput_ReturnsTrue(string category)
  {
    var items = new[] { new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOutput_ReturnsFalse(string name, string category1, string category2)
  {
    if (category1 == category2) {
      return;
    }

    var items = new[] { new CategoryDeclAst(AstNulls.At, name, category1), new CategoryDeclAst(AstNulls.At, name, category2) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOption_ReturnsFalse(string category)
  {
    var items = new[] { new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Single }, new CategoryDeclAst(AstNulls.At, category) { Option = CategoryOption.Sequential } };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override CategoryDeclAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description, name);
}
