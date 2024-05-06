using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;
using NSubstitute;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public abstract class TestDomainAsts<TItem, TItemInput>
  : TestTyped<AstDomain, AstDomain<TItem>, string, TItem>
  where TItem : AstAbbreviated, IGqlpDomainItem
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_SameKinds_ReturnsGood(string name)
  {
    AstDomain<TItem>[] items = new[] { MakeDescribed(name), MakeDescribed(name) };

    ITokenMessages result = Merger.CanMerge(items);

    result.Should().BeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_DifferentKinds_ReturnsErrors(string name)
  {
    DomainKind domainKind = MakeDescribed(name).DomainKind == DomainKind.String
      ? DomainKind.Number
      : DomainKind.String;
    AstDomain<TItem>[] items = new[] { MakeDescribed(name) with { DomainKind = domainKind }, MakeDescribed(name) };

    ITokenMessages result = Merger.CanMerge(items);

    result.Should().NotBeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ItemsCantMerge_ReturnsErrors(string name, TItemInput input)
  {
    AstDomain<TItem>[] items = new[] {
      MakeDescribed(name) with { Members = MakeItems(input) },
      MakeDescribed(name) with { Members = MakeItems(input) },
    };
    MergeItems.CanMerge([]).ReturnsForAnyArgs(new TokenMessages(new TokenMessage(AstNulls.At, "Error!")));

    ITokenMessages result = Merger.CanMerge(items);

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
