using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestGroups<TItem> : TestBase<TItem>
  where TItem : AstBase
{
  protected abstract GroupsMerger<TItem> MergerGroups { get; }

  protected override IMerge<TItem> MergerBase => MergerGroups;
}
