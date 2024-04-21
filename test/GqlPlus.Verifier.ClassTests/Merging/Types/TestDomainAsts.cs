using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;
using NSubstitute;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Types;

public abstract class TestDomainAsts<TItem, TItemInput>
  : TestTyped<AstDomain, AstDomain<TItem>, string, TItem>
  where TItem : AstBase, IAstDomainItem
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_SameKinds_ReturnsGood(string name)
  {
    var items = new[] { MakeDescribed(name), MakeDescribed(name) };

    var result = Merger.CanMerge(items);

    result.Should().BeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_DifferentKinds_ReturnsErrors(string name)
  {
    var domain = MakeDescribed(name).Domain == DomainDomain.String
      ? DomainDomain.Number
      : DomainDomain.String;
    var items = new[] { MakeDescribed(name) with { Domain = domain }, MakeDescribed(name) };

    var result = Merger.CanMerge(items);

    result.Should().NotBeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ItemsCantMerge_ReturnsErrors(string name, TItemInput input)
  {
    var items = new[] {
      MakeDescribed(name) with { Items = MakeItems(input) },
      MakeDescribed(name) with { Items = MakeItems(input) },
    };
    MergeItems.CanMerge([]).ReturnsForAnyArgs(new TokenMessages(new TokenMessage(AstNulls.At, "Error!")));

    var result = Merger.CanMerge(items);

    result.Should().NotBeEmpty();
  }

  internal readonly IMerge<TItem> MergeItems;
  internal readonly MergeDomains<TItem> Merger;

  protected TestDomainAsts(ITestOutputHelper outputHelper)
  {
    MergeItems = Merger<TItem>();

    Merger = new(outputHelper.ToLoggerFactory(), MergeItems);
  }

  internal override AstTypeMerger<AstDomain, AstDomain<TItem>, string, TItem> MergerTyped => Merger;

  protected abstract TItem[] MakeItems(TItemInput input);

  protected override string MakeParent(string parent)
    => parent;
}
