using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Schema.Simple;

public abstract class TestDomainItems<TItem, TInput>
  : TestGroupsMerger<TItem, TInput>
  where TItem : IGqlpDomainItem
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSame_ReturnsGood(TInput input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSame_ReturnsExpected(TInput input)
    => Merge_Expected(
      [MakeAst(input), MakeAst(input)],
      MakeAst(input));

  [Theory, RepeatData]
  public void Merge_TwoAstsDifferent_ReturnsExpected(TInput input1, TInput input2)
    => this
      .SkipNull(input1)
      .SkipIf(input1.Equals(input2))
      .Merge_Expected(
        [MakeAst(input1), MakeAst(input2)],
        MakeAst(input1), MakeAst(input2));

  protected abstract TItem MakeItem(TInput input, bool excludes);

  protected override TItem MakeAst(TInput input)
    => MakeItem(input, false);
}
