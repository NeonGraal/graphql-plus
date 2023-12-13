using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestDistinct<TItem>
  where TItem : AstBase
{
  protected abstract DistinctsMerger<TItem> MergerDistinct { get; }

  protected abstract TItem MakeDistinct(string name);

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
   => CanMerge_False([]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string name)
    => CanMerge_True([MakeDistinct(name)]);

  protected void CanMerge_False(TItem[] items, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = MergerDistinct.CanMerge(items);

    result.Should().BeFalse();
  }

  protected void CanMerge_True(TItem[] items)
  {
    var result = MergerDistinct.CanMerge(items);

    result.Should().BeTrue();
  }
}
