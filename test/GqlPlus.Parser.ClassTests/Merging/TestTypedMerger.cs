﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

public abstract class TestTypedMerger<TBase, TType, TParent, TItem>
  : TestAliasedMerger<TType>
  where TBase : IGqlpType
  where TType : IGqlpType<TParent>, TBase
  where TParent : IGqlpDescribed, IEquatable<TParent>
  where TItem : IGqlpError
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameParent_ReturnsGood(string name, string type)
    => CanMerge_Good(
      MakeTyped(name, parent: MakeParent(type)),
      MakeTyped(name, parent: MakeParent(type)));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentParents_ReturnsErrors(string name, string type1, string type2)
    => this
      .SkipEqual(type1, type2)
      .CanMerge_Errors(
        MakeTyped(name, parent: MakeParent(type1)),
        MakeTyped(name, parent: MakeParent(type2)));

  internal abstract AstTypeMerger<TBase, TType, TParent, TItem> MergerTyped { get; }
  internal override GroupsMerger<TType> MergerGroups => MergerTyped;

  protected abstract TType MakeTyped(string name, string[]? aliases = null, string description = "", TParent? parent = default);
  protected abstract TParent? MakeParent(string? parent);
  protected override TType MakeAliased(string name, string[]? aliases = null, string description = "")
    => MakeTyped(name, aliases, description);
}
