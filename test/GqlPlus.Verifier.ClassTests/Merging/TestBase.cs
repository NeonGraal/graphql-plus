using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestBase<TItem>
  where TItem : AstBase
{
  protected abstract IMerge<TItem> MergerBase { get; }

  protected abstract TItem MakeDistinct(string name);

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
   => CanMerge_False([]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string name)
    => CanMerge_True([MakeDistinct(name)]);

  [Fact]
  public void Merge_NoItems_ThrowsException()
  {
    Func<TItem[]> action = () => MergerBase.Merge([]);

    action.Should().Throw<InvalidOperationException>();
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_OneItem_ReturnsItem(string name)
  {
    var item = MakeDistinct(name);

    Merge_Expected([item], item);
  }

  protected void CanMerge_False(TItem[] items, bool skipIf = false)
  {
    if (skipIf) {
      return;
    }

    var result = MergerBase.CanMerge(items);

    result.Should().BeFalse();
  }

  protected void CanMerge_True(TItem[] items)
  {
    var result = MergerBase.CanMerge(items);

    result.Should().BeTrue();
  }

  protected void Merge_Expected(TItem[] items, params TItem[] expected)
  {
    var result = MergerBase.Merge(items);

    using var scope = new AssertionScope();

    result.Should().BeOfType<TItem[]>();
    result.Should().BeEquivalentTo(expected);
  }
}
