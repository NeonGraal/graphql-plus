using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public abstract class TestSimpleMerger<TBase, TType, TItem, TItemInput>
  : TestTypedMerger<TBase, TType, IGqlpTypeRef, TItem>
  where TBase : IGqlpType
  where TType : IGqlpSimple<TItem>, TBase
  where TItem : IGqlpError
{
  [Theory, RepeatData]
  public void CanMerge_ItemsCantMerge_ReturnsErrors(string name, TItemInput input)
  {
    TType[] items = [
      MakeSimple(name, items: MakeItems(input)),
      MakeSimple(name, items: MakeItems(input)),
    ];
    MergeItems.CanMerge([]).ReturnsForAnyArgs(new Messages(new TokenMessage(AstNulls.At, "Error!")));

    IMessages result = MergerSimple.CanMerge(items);

    result.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsItems_ReturnsExpected(string name, TItemInput input, TItemInput expected)
  {
    TType[] items = [
      MakeSimple(name, items: MakeItems(input)),
      MakeSimple(name, items: MakeItems(input)),
    ];
    MergeItems.Merge([]).ReturnsForAnyArgs(MakeItems(expected));

    Merge_Expected(items, MakeSimple(name, items: MakeItems(expected)));
  }

  internal readonly IMerge<TItem> MergeItems;
  internal sealed override AstTypeMerger<TBase, TType, IGqlpTypeRef, TItem> MergerTyped => MergerSimple;
  internal abstract AstSimpleMerger<TBase, TType, TItem> MergerSimple { get; }

  protected TestSimpleMerger()
    => MergeItems = Merger<TItem>();

  protected abstract TItem[] MakeItems(TItemInput input);
  protected abstract TType MakeSimple(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpTypeRef? parent = default,
    IEnumerable<TItem>? items = null
  );

  protected sealed override TType MakeTyped(string name, string[]? aliases = null, string description = "", IGqlpTypeRef? parent = null)
    => MakeSimple(name, aliases, description, parent, []);

  protected sealed override IGqlpTypeRef? MakeParent(string? parent)
    => parent.IsWhiteSpace() ? null : new TypeRefAst(AstNulls.At, parent!);
}
