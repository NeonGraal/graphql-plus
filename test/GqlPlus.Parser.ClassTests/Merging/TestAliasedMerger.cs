using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Schema;

namespace GqlPlus.Merging;

public abstract class TestAliasedMerger<TAst>
  : TestAliasedMerger<TAst, string>
  where TAst : IGqlpAliased
{
  protected override bool InputEquals(string? input1, string? input2)
    => string.Equals(input1, input2, StringComparison.Ordinal);
}

public abstract class TestAliasedMerger<TAst, TInput>
  : TestDescriptionsMerger<TAst, TInput>
  where TAst : IGqlpAliased
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneAlias_ReturnsGood(TInput input, string alias)
  => CanMerge_Good([MakeAliased(input, []), MakeAliased(input, [alias])]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameAlias_ReturnsGood(TInput input, string alias)
    => CanMerge_Good([MakeAliased(input, [alias]), MakeAliased(input, [alias])]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentAliases_ReturnsGood(TInput input, string alias1, string alias2)
    => CanMerge_Good([MakeAliased(input, [alias1]), MakeAliased(input, [alias2])]);

  [Theory, RepeatData]
  public void CanMerge_ThreeAstsOneAlias_ReturnsGood(TInput input1, TInput input2, string alias)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .CanMerge_Good([MakeAliased(input1, []), MakeAliased(input2, []), MakeAliased(input1, [alias])]);

  [Theory, RepeatData]
  public void CanMerge_ThreeAstsSameAlias_ReturnsErrors(TInput input1, TInput input2, string alias)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .CanMerge_Errors([MakeAliased(input1, []), MakeAliased(input2, [alias]), MakeAliased(input1, [alias])]);

  [Theory, RepeatData]
  public void CanMerge_ThreeAstsDifferentAliases_ReturnsGood(TInput input1, TInput input2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .SkipEqual(alias1, alias2)
      .CanMerge_Good([MakeAliased(input1, []), MakeAliased(input2, [alias1]), MakeAliased(input1, [alias2])]);

  [Theory, RepeatData]
  public void CanMerge_ThreeAstsTwoAliases_ReturnsGood(TInput input1, TInput input2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .CanMerge_Good([MakeAliased(input1, [alias1]), MakeAliased(input2, []), MakeAliased(input1, [alias2])]);

  [Theory, RepeatData]
  public void CanMerge_ThreeAstsMixedAliases_ReturnsErrors(TInput input1, TInput input2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .CanMerge_Errors([MakeAliased(input1, [alias1]), MakeAliased(input2, [alias2]), MakeAliased(input1, [alias1, alias2])]);

  [Theory, RepeatData]
  public void CanMerge_ThreeAstsManyAliases_ReturnsErrors(TInput input1, TInput input2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .CanMerge_Errors([MakeAliased(input1, [alias1]), MakeAliased(input2, [alias1, alias2]), MakeAliased(input1, [alias2])]);

  [Theory, RepeatData]
  public void Merge_TwoAstsOneAlias_ReturnsExpected(TInput input, string alias)
    => Merge_Expected([MakeAliased(input, []), MakeAliased(input, [alias])], MakeAliased(input, [alias]));

  [Theory, RepeatData]
  public void Merge_TwoAstsSameAlias_ReturnsExpected(TInput input, string alias)
    => Merge_Expected([MakeAliased(input, [alias]), MakeAliased(input, [alias])], MakeAliased(input, [alias]));

  [Theory, RepeatData]
  public void Merge_TwoAstsTwoAlias_ReturnsExpected(TInput input, string alias1, string alias2)
    => this
      .SkipEqual(alias1, alias2)
      .Merge_Expected(
        [MakeAliased(input, [alias1]), MakeAliased(input, [alias2])],
        MakeAliased(input, [alias1, alias2]));

  [Theory, RepeatData]
  public void Merge_ThreeAstsOneAlias_ReturnsExpected(TInput input1, TInput input2, string alias)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .Merge_Expected(
        [MakeAliased(input1, []), MakeAliased(input2, []), MakeAliased(input1, [alias])],
        MakeAliased(input1, [alias]), MakeAliased(input2, []));

  [Theory, RepeatData]
  public void Merge_ThreeAstsDifferentAliases_ReturnsExpected(TInput input1, TInput input2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .SkipEqual(alias1, alias2)
      .Merge_Expected(
        [MakeAliased(input1, []), MakeAliased(input2, [alias1]), MakeAliased(input1, [alias2])],
        MakeAliased(input1, [alias2]), MakeAliased(input2, [alias1]));

  [Theory, RepeatData]
  public void Merge_ThreeAstsTwoAliases_ReturnsExpected(TInput input1, TInput input2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentInput || InputEquals(input1, input2))
      .SkipEqual(alias1, alias2)
      .Merge_Expected(
        [MakeAliased(input1, [alias1]), MakeAliased(input2, []), MakeAliased(input1, [alias2])],
        MakeAliased(input1, [alias1, alias2]), MakeAliased(input2, []));

  protected abstract TAst MakeAliased(TInput input, string[] aliases, string description = "");
  protected override TAst MakeDescribed(TInput input, string description = "")
    => MakeAliased(input, [], description);
}
