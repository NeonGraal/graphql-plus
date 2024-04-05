using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAliased<TAst>
  : TestDescriptions<TAst>
  where TAst : AstAliased
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneAlias_ReturnsTrue(string name, string alias)
    => CanMerge_True([MakeAliased(name, []), MakeAliased(name, [alias])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameAlias_ReturnsTrue(string name, string alias)
    => CanMerge_True([MakeAliased(name, [alias]), MakeAliased(name, [alias])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentAliases_ReturnsTrue(string name, string alias1, string alias2)
    => CanMerge_True([MakeAliased(name, [alias1]), MakeAliased(name, [alias2])]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_ThreeAstsOneAlias_ReturnsTrue(string name1, string name2, string alias)
    => CanMerge_True([MakeAliased(name1, []), MakeAliased(name2, []), MakeAliased(name1, [alias])],
      SkipDifferentNames);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_ThreeAstsSameAlias_ReturnsFalse(string name1, string name2, string alias)
    => CanMerge_False(
      [MakeAliased(name1, []), MakeAliased(name2, [alias]), MakeAliased(name1, [alias])],
      SkipDifferentNames || name1 == name2);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_ThreeAstsDifferentAliases_ReturnsTrue(string name1, string name2, string alias1, string alias2)
    => CanMerge_True(
      [MakeAliased(name1, []), MakeAliased(name2, [alias1]), MakeAliased(name1, [alias2])],
      SkipDifferentNames || name1 == name2 || alias1 == alias2);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_ThreeAstsTwoAliases_ReturnsTrue(string name1, string name2, string alias1, string alias2)
    => CanMerge_True([MakeAliased(name1, [alias1]), MakeAliased(name2, []), MakeAliased(name1, [alias2])],
      SkipDifferentNames || name1 == name2);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_ThreeAstsMixedAliases_ReturnsFalse(string name1, string name2, string alias1, string alias2)
    => CanMerge_False(
      [MakeAliased(name1, [alias1]), MakeAliased(name2, [alias2]), MakeAliased(name1, [alias1, alias2])],
      SkipDifferentNames || name1 == name2);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_ThreeAstsManyAliases_ReturnsFalse(string name1, string name2, string alias1, string alias2)
    => CanMerge_False(
      [MakeAliased(name1, [alias1]), MakeAliased(name2, [alias1, alias2]), MakeAliased(name1, [alias2])],
      SkipDifferentNames || name1 == name2);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneAlias_ReturnsExpected(string name, string alias)
    => Merge_Expected([MakeAliased(name, []), MakeAliased(name, [alias])], MakeAliased(name, [alias]));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameAlias_ReturnsExpected(string name, string alias)
    => Merge_Expected([MakeAliased(name, [alias]), MakeAliased(name, [alias])], MakeAliased(name, [alias]));

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstsTwoAlias_ReturnsExpected(string name, string alias1, string alias2)
    => Merge_Expected([MakeAliased(name, [alias1]), MakeAliased(name, [alias2])],
      alias1 == alias2, MakeAliased(name, [alias1, alias2]));

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_ThreeAstsOneAlias_ReturnsExpected(string name1, string name2, string alias)
    => Merge_Expected([MakeAliased(name1, []), MakeAliased(name2, []), MakeAliased(name1, [alias])],
      SkipDifferentNames || name1 == name2, MakeAliased(name1, [alias]), MakeAliased(name2, []));

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_ThreeAstsDifferentAliases_ReturnsExpected(string name1, string name2, string alias1, string alias2)
    => Merge_Expected([MakeAliased(name1, []), MakeAliased(name2, [alias1]), MakeAliased(name1, [alias2])],
      SkipDifferentNames || name1 == name2 || alias1 == alias2, MakeAliased(name1, [alias2]), MakeAliased(name2, [alias1]));

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_ThreeAstsTwoAliases_ReturnsExpected(string name1, string name2, string alias1, string alias2)
    => Merge_Expected([MakeAliased(name1, [alias1]), MakeAliased(name2, []), MakeAliased(name1, [alias2])],
      SkipDifferentNames || name1 == name2 || alias1 == alias2, MakeAliased(name1, [alias1, alias2]), MakeAliased(name2, []));

  protected abstract TAst MakeAliased(string name, string[] aliases, string description = "");
  protected override TAst MakeDescribed(string name, string description = "")
    => MakeAliased(name, [], description);
}
