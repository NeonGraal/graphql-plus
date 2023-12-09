using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestDistinct<TItem>
  where TItem : AstBase
{
  protected abstract DistinctMerger<TItem> MergerDistinct { get; }

  protected abstract TItem MakeDistinct(string name);

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
  {
    var items = Array.Empty<TItem>();

    var result = MergerDistinct.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string name)
  {
    var items = new[] { MakeDistinct(name) };

    var result = MergerDistinct.CanMerge(items);

    result.Should().BeTrue();
  }
}
