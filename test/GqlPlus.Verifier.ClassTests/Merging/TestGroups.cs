using GqlPlus.Verifier.Ast;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public abstract class TestGroups<TItem>
  : TestBase<TItem>
  where TItem : AstBase
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentNames_ReturnsTrue(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    CanMerge_True([MakeDistinct(name1), MakeDistinct(name2)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsDifferentName_ReturnsItems(string name1, string name2)
  {
    var item1 = MakeDistinct(name1);
    var item2 = MakeDistinct(name2);

    Merge_Expected([item1, item2], name1 == name2, item2, item1);
  }

  protected abstract GroupsMerger<TItem> MergerGroups { get; }

  protected override IMerge<TItem> MergerBase => MergerGroups;

  protected IMerge<TResult> Merger<TResult>()
  {
    var result = Substitute.For<IMerge<TResult>>();
    result.CanMerge([]).ReturnsForAnyArgs(true);
    return result;
  }
}
