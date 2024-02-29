using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestTyped<TBase, TType, TParent, TItem>
  : TestAliased<TType>
  where TBase : AstAliased
  where TType : AstType<TParent>, TBase
  where TParent : IEquatable<TParent>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameParent_ReturnsTrue(string name, string type)
    => CanMerge_True([
      MakeTyped(name) with { Parent = MakeParent(type) },
      MakeTyped(name) with { Parent = MakeParent(type) }]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentParents_ReturnsFalse(string name, string type1, string type2)
    => CanMerge_False([
      MakeTyped(name) with { Parent = MakeParent(type1) },
      MakeTyped(name) with { Parent = MakeParent(type2) }],
      type1 == type2);

  internal abstract AstTypeMerger<TBase, TType, TParent, TItem> MergerTyped { get; }
  internal override GroupsMerger<TType> MergerGroups => MergerTyped;

  protected abstract TType MakeTyped(string name, string description = "");
  protected abstract TParent MakeParent(string parent);
  protected override TType MakeAliased(string name, string[] aliases, string description = "")
    => MakeTyped(name, description) with { Aliases = aliases };
}
