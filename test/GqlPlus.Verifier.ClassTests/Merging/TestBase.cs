using GqlPlus.Verifier.Ast;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

[TracePerTest]

public abstract class TestBase<TItem>
  where TItem : AstBase
{
  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
   => CanMerge_False([]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string name)
    => CanMerge_True([MakeDistinct(name)]);

  [Fact]
  public void Merge_NullItems_ReturnsEmpty()
  {
    var result = MergerBase.Merge(null!);

    result.Should().BeEmpty();
  }

  [Fact]
  public void Merge_NoItems_ReturnsEmpty()
  {
    var result = MergerBase.Merge([]);

    result.Should().BeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_OneItem_ReturnsItem(string name)
  {
    var item = MakeDistinct(name);

    Merge_Expected([item], item);
  }

  protected abstract IMerge<TItem> MergerBase { get; }

  protected abstract TItem MakeDistinct(string name);

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

  protected void Merge_Expected(TItem[] items, bool skipIf, params TItem[] expected)
  {
    if (skipIf) {
      return;
    }

    Merge_Expected(items, expected);
  }

  protected void Merge_Expected(TItem[] items, params TItem[] expected)
  {

    var result = MergerBase.Merge(items);

    using var scope = new AssertionScope();

    result.Should().BeAssignableTo<IEnumerable<TItem>>();
    result.Should().BeEquivalentTo(expected);
  }

  protected IMerge<TResult> Merger<TResult>()
  {
    var result = Substitute.For<IMerge<TResult>>();
    result.CanMerge([]).ReturnsForAnyArgs(true);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<TResult>>());
    return result;
  }
}
