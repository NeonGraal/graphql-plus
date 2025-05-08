using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public abstract class TestDomainItemAsts<TItem, TInput>
  : TestGroupsMerger<TItem, TInput>
  where TItem : IGqlpDomainItem
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSame_ReturnsGood(TInput name)
    => CanMerge_Good([MakeAst(name), MakeAst(name)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSame_ReturnsExpected(TInput name)
    => Merge_Expected(
      [MakeAst(name), MakeAst(name)],
      MakeAst(name));

  [Theory, RepeatData]
  public void Merge_TwoAstsDifferent_ReturnsExpected(TInput name1, TInput name2)
    => this
      .SkipNull(name1)
      .SkipIf(name1.Equals(name2))
      .Merge_Expected(
        [MakeAst(name1), MakeAst(name2)],
        MakeAst(name1), MakeAst(name2));

  protected abstract TItem MakeItem(TInput input, bool excludes);

  protected override TItem MakeAst(TInput input)
    => MakeItem(input, false);
}
