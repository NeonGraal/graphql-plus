using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Schema;

public abstract class TestAliased<TAst>
  : TestDescriptionsMerger<TAst>
  where TAst : IGqlpAliased
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneAlias_ReturnsGood(string name, string alias)
    => CanMerge_Good([MakeAliased(name, []), MakeAliased(name, [alias])]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameAlias_ReturnsGood(string name, string alias)
    => CanMerge_Good([MakeAliased(name, [alias]), MakeAliased(name, [alias])]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentAliases_ReturnsGood(string name, string alias1, string alias2)
    => CanMerge_Good([MakeAliased(name, [alias1]), MakeAliased(name, [alias2])]);

  [SkippableTheory, RepeatData]
  public void CanMerge_ThreeAstsOneAlias_ReturnsGood(string name1, string name2, string alias)
    => this
      .SkipIf(SkipDifferentNames)
      .CanMerge_Good([MakeAliased(name1, []), MakeAliased(name2, []), MakeAliased(name1, [alias])]);

  [SkippableTheory, RepeatData]
  public void CanMerge_ThreeAstsSameAlias_ReturnsErrors(string name1, string name2, string alias)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .CanMerge_Errors([MakeAliased(name1, []), MakeAliased(name2, [alias]), MakeAliased(name1, [alias])]);

  [SkippableTheory, RepeatData]
  public void CanMerge_ThreeAstsDifferentAliases_ReturnsGood(string name1, string name2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .SkipIf(alias1 == alias2)
      .CanMerge_Good([MakeAliased(name1, []), MakeAliased(name2, [alias1]), MakeAliased(name1, [alias2])]);

  [SkippableTheory, RepeatData]
  public void CanMerge_ThreeAstsTwoAliases_ReturnsGood(string name1, string name2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .CanMerge_Good([MakeAliased(name1, [alias1]), MakeAliased(name2, []), MakeAliased(name1, [alias2])]);

  [SkippableTheory, RepeatData]
  public void CanMerge_ThreeAstsMixedAliases_ReturnsErrors(string name1, string name2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .CanMerge_Errors([MakeAliased(name1, [alias1]), MakeAliased(name2, [alias2]), MakeAliased(name1, [alias1, alias2])]);

  [SkippableTheory, RepeatData]
  public void CanMerge_ThreeAstsManyAliases_ReturnsErrors(string name1, string name2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .CanMerge_Errors([MakeAliased(name1, [alias1]), MakeAliased(name2, [alias1, alias2]), MakeAliased(name1, [alias2])]);

  [Theory, RepeatData]
  public void Merge_TwoAstsOneAlias_ReturnsExpected(string name, string alias)
    => Merge_Expected([MakeAliased(name, []), MakeAliased(name, [alias])], MakeAliased(name, [alias]));

  [Theory, RepeatData]
  public void Merge_TwoAstsSameAlias_ReturnsExpected(string name, string alias)
    => Merge_Expected([MakeAliased(name, [alias]), MakeAliased(name, [alias])], MakeAliased(name, [alias]));

  [SkippableTheory, RepeatData]
  public void Merge_TwoAstsTwoAlias_ReturnsExpected(string name, string alias1, string alias2)
    => this
      .SkipIf(alias1 == alias2)
      .Merge_Expected(
        [MakeAliased(name, [alias1]), MakeAliased(name, [alias2])],
        MakeAliased(name, [alias1, alias2]));

  [SkippableTheory, RepeatData]
  public void Merge_ThreeAstsOneAlias_ReturnsExpected(string name1, string name2, string alias)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .Merge_Expected(
        [MakeAliased(name1, []), MakeAliased(name2, []), MakeAliased(name1, [alias])],
        MakeAliased(name1, [alias]), MakeAliased(name2, []));

  [SkippableTheory, RepeatData]
  public void Merge_ThreeAstsDifferentAliases_ReturnsExpected(string name1, string name2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .SkipIf(alias1 == alias2)
      .Merge_Expected(
        [MakeAliased(name1, []), MakeAliased(name2, [alias1]), MakeAliased(name1, [alias2])],
        MakeAliased(name1, [alias2]), MakeAliased(name2, [alias1]));

  [SkippableTheory, RepeatData]
  public void Merge_ThreeAstsTwoAliases_ReturnsExpected(string name1, string name2, string alias1, string alias2)
    => this
      .SkipIf(SkipDifferentNames)
      .SkipIf(name1 == name2)
      .SkipIf(alias1 == alias2)
      .Merge_Expected(
        [MakeAliased(name1, [alias1]), MakeAliased(name2, []), MakeAliased(name1, [alias2])],
        MakeAliased(name1, [alias1, alias2]), MakeAliased(name2, []));

  protected abstract TAst MakeAliased(string name, string[] aliases, string description = "");
  protected override TAst MakeDescribed(string name, string description = "")
    => MakeAliased(name, [], description);
}
