﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Token;

using NSubstitute;

namespace GqlPlus.Merging.Simple;

public abstract class TestDomainAsts<TItem, TItemInput>
  : TestTyped<IGqlpDomain, IGqlpDomain<TItem>, string, TItem>
  where TItem : class, IGqlpDomainItem
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_SameKinds_ReturnsGood(string name)
  {
    IGqlpDomain<TItem>[] items = [MakeDomain(name), MakeDomain(name)];

    ITokenMessages result = Merger.CanMerge(items);

    result.Should().BeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_DifferentKinds_ReturnsErrors(string name)
  {
    DomainKind domainKind = MakeDescribed(name).DomainKind == DomainKind.String
      ? DomainKind.Number
      : DomainKind.String;
    IGqlpDomain<TItem>[] items = [MakeDomain(name, kind: domainKind), MakeDomain(name)];

    ITokenMessages result = Merger.CanMerge(items);

    result.Should().NotBeEmpty();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ItemsCantMerge_ReturnsErrors(string name, TItemInput input)
  {
    IGqlpDomain<TItem>[] items = [
      MakeDomain(name, items: MakeItems(input)),
      MakeDomain(name, items: MakeItems(input)),
    ];
    MergeItems.CanMerge([]).ReturnsForAnyArgs(new TokenMessages(new TokenMessage(AstNulls.At, "Error!")));

    ITokenMessages result = Merger.CanMerge(items);

    result.Should().NotBeEmpty();
  }

  internal readonly IMerge<TItem> MergeItems;
  internal abstract IDomainMerger<TItem> Merger { get; }

  protected TestDomainAsts()
    => MergeItems = Merger<TItem>();

  // internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<TItem>, string, TItem> MergerTyped => Merger;

  protected abstract TItem[] MakeItems(TItemInput input);
  protected abstract IGqlpDomain<TItem> MakeDomain(
    string name,
    string[]? aliases = null,
    string description = "",
    string? parent = default,
    DomainKind? kind = null,
    IEnumerable<TItem>? items = null
  );

  protected override IGqlpDomain<TItem> MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => MakeDomain(name, aliases, description, parent);

  protected override string MakeParent(string parent)
    => parent;
}
