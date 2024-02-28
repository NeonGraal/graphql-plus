using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public abstract class TestScalarAsts<TItem, TItemInput>
  : TestTyped<AstScalar, AstScalar<TItem>, string, TItem>
  where TItem : IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_SameKinds_ReturnsTrue(string name)
  {
    var items = new[] { MakeDescribed(name), MakeDescribed(name) };

    var result = Merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_DifferentKinds_ReturnsFalse(string name)
  {
    var kind = MakeDescribed(name).Kind == ScalarKind.String
      ? ScalarKind.Number
      : ScalarKind.String;
    var items = new[] { MakeDescribed(name) with { Kind = kind }, MakeDescribed(name) };

    var result = Merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ItemsCantMerge_ReturnsFalse(string name, TItemInput input)
  {
    var items = new[] {
      MakeDescribed(name) with { Items = MakeItems(input) },
      MakeDescribed(name) with { Items = MakeItems(input) },
    };
    MergeItems.CanMerge([]).ReturnsForAnyArgs(false);

    var result = Merger.CanMerge(items);

    result.Should().BeFalse();
  }

  internal readonly IMerge<TItem> MergeItems;
  internal readonly MergeScalars<TItem> Merger;

  protected TestScalarAsts()
  {
    MergeItems = Merger<TItem>();

    Merger = new(MergeItems);
  }

  internal override AstTypeMerger<AstScalar, AstScalar<TItem>, string, TItem> MergerTyped => Merger;

  protected abstract TItem[] MakeItems(TItemInput input);

  protected override string MakeParent(string parent)
    => parent;
}
