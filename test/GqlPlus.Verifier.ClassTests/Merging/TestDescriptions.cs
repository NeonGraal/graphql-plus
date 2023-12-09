using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestDescriptions<TItem>
  where TItem : IAstDescribed
{
  protected abstract DescribedMerger<TItem> Merger { get; }

  protected abstract TItem MakeItem(string name, string description = "");

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneDescription_ReturnsTrue(string name, string description)
  {
    var items = new[] { MakeItem(name, description), MakeItem(name) };

    var result = Merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDescription_ReturnsTrue(string name, string description)
  {
    var items = new[] { MakeItem(name, description), MakeItem(name, description) };

    var result = Merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDescription_ReturnsFalse(string name, string description1, string description2)
  {
    if (description1 == description2) {
      return;
    }

    var items = new[] { MakeItem(name, description1), MakeItem(name, description2) };

    var result = Merger.CanMerge(items);

    result.Should().BeFalse();
  }
}
