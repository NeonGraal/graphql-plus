using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeCategoriesTests
  : TestDescriptions<CategoryDeclAst>
{
  private readonly MergeCategories _merger = new();

  protected override DescribedMerger<CategoryDeclAst> Merger => _merger;

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
  {
    var items = Array.Empty<CategoryDeclAst>();

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string category)
  {
    var items = new[] { new CategoryDeclAst(AstNulls.At, category) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameOutput_ReturnsTrue(string category)
  {
    var items = new[] { new CategoryDeclAst(AstNulls.At, category), new CategoryDeclAst(AstNulls.At, category) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOutput_ReturnsFalse(string category1, string category2)
  {
    var items = new[] { new CategoryDeclAst(AstNulls.At, category1), new CategoryDeclAst(AstNulls.At, category2) };

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

  protected override CategoryDeclAst MakeItem(string name, string description = "")
    => new(AstNulls.At, name, description, name);
}
