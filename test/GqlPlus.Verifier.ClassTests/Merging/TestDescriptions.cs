using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestDescriptions<TItem>
  : TestDistinct<TItem>
  where TItem : AstBase, IAstDescribed
{
  protected abstract DescribedsMerger<TItem> MergerDescribed { get; }
  protected override DistinctsMerger<TItem> MergerDistinct => MergerDescribed;

  protected abstract TItem MakeDescribed(string name, string description = "");
  protected override TItem MakeDistinct(string name)
    => MakeDescribed(name);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneDescription_ReturnsTrue(string name, string description)
  {
    var items = new[] { MakeDescribed(name, description), MakeDescribed(name) };

    var result = MergerDescribed.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDescription_ReturnsTrue(string name, string description)
  {
    var items = new[] { MakeDescribed(name, description), MakeDescribed(name, description) };

    var result = MergerDescribed.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDescription_ReturnsFalse(string name, string description1, string description2)
  {
    if (description1 == description2) {
      return;
    }

    var items = new[] { MakeDescribed(name, description1), MakeDescribed(name, description2) };

    var result = MergerDescribed.CanMerge(items);

    result.Should().BeFalse();
  }
}
