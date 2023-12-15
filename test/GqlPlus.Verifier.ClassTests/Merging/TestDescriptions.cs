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
    => CanMerge_True([MakeDescribed(name, description), MakeDescribed(name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDescription_ReturnsTrue(string name, string description)
  => CanMerge_True([MakeDescribed(name, description), MakeDescribed(name, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDescription_ReturnsFalse(string name, string description1, string description2)
  => CanMerge_False([MakeDescribed(name, description1), MakeDescribed(name, description2)], description1 == description2);
}
