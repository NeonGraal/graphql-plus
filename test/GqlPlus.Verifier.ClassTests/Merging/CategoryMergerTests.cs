using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class CategoryMergerTests
{
  private readonly CategoryMerger _merger = new();

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
  {
    var items = Array.Empty<CategoryDeclAst>();

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }
}
