using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public abstract class TestTyped<TBase, TType, TParent, TItem>
  : TestAliased<TType>
  where TBase : IGqlpType
  where TType : AstType<TParent>, TBase
  where TParent : IEquatable<TParent>
  where TItem : AstBase
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameParent_ReturnsGood(string name, string type)
    => CanMerge_Good(
      MakeTyped(name) with { Parent = MakeParent(type) },
      MakeTyped(name) with { Parent = MakeParent(type) });

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentParents_ReturnsErrors(string name, string type1, string type2)
    => this
      .SkipIf(type1 == type2)
      .CanMerge_Errors(
        MakeTyped(name) with { Parent = MakeParent(type1) },
        MakeTyped(name) with { Parent = MakeParent(type2) });

  internal abstract AstTypeMerger<TBase, TType, TParent, TItem> MergerTyped { get; }
  internal override GroupsMerger<TType> MergerGroups => MergerTyped;

  protected abstract TType MakeTyped(string name, string description = "");
  protected abstract TParent MakeParent(string parent);
  protected override TType MakeAliased(string name, string[] aliases, string description = "")
    => MakeTyped(name, description) with { Aliases = aliases };
}
