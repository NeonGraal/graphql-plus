using System.Xml.Linq;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAliased<TItem>
  : TestDescriptions<TItem>
  where TItem : AstAliased
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneAlias_ReturnsTrue(string name, string alias)
    => CanMerge_True([MakeAliased(name, []), MakeAliased(name, [alias])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameAlias_ReturnsTrue(string name, string alias)
  => CanMerge_True([MakeAliased(name, [alias]), MakeAliased(name, [alias])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentAliases_ReturnsTrue(string name, string alias1, string alias2)
  => CanMerge_True([MakeAliased(name, [alias1]), MakeAliased(name, [alias2])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ThreeItemsOneAlias_ReturnsTrue(string name1, string name2, string alias)
    => CanMerge_True([MakeAliased(name1, []), MakeAliased(name2, []), MakeAliased(name1, [alias])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ThreeItemsSameAlias_ReturnsFalse(string name1, string name2, string alias)
  => CanMerge_False([MakeAliased(name1, []), MakeAliased(name2, [alias]), MakeAliased(name1, [alias])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ThreeItemsDifferentAliases_ReturnsTrue(string name1, string name2, string alias1, string alias2)
  => CanMerge_True([MakeAliased(name1, []), MakeAliased(name2, [alias1]), MakeAliased(name1, [alias2])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ThreeItemsTwoAliases_ReturnsTrue(string name1, string name2, string alias1, string alias2)
  => CanMerge_True([MakeAliased(name1, [alias1]), MakeAliased(name2, []), MakeAliased(name1, [alias2])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ThreeItemsMixedAliases_ReturnsFalse(string name1, string name2, string alias1, string alias2)
  => CanMerge_False([MakeAliased(name1, [alias1]), MakeAliased(name2, [alias2]), MakeAliased(name1, [alias1, alias2])]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_ThreeItemsManyAliases_ReturnsFalse(string name1, string name2, string alias1, string alias2)
  => CanMerge_False([MakeAliased(name1, [alias1]), MakeAliased(name2, [alias1, alias2]), MakeAliased(name1, [alias2])]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsOneAlias_ReturnsExpected(string name, string alias)
    => Merge_Expected([MakeAliased(name, []), MakeAliased(name, [alias])], MakeAliased(name, [alias]));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsSameAlias_ReturnsExpected(string name, string alias)
  => Merge_Expected([MakeAliased(name, [alias]), MakeAliased(name, [alias])], MakeAliased(name, [alias]));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsTwoAlias_ReturnsExpected(string name, string alias1, string alias2)
  => Merge_Expected([MakeAliased(name, [alias1]), MakeAliased(name, [alias2])],
    alias1 == alias2, MakeAliased(name, [alias1, alias2]));

  [Theory, RepeatData(Repeats)]
  public void Merge_ThreeItemsOneAlias_ReturnsExpected(string name1, string name2, string alias)
    => Merge_Expected([MakeAliased(name1, []), MakeAliased(name2, []), MakeAliased(name1, [alias])],
      MakeAliased(name1, [alias]), MakeAliased(name2, []));

  [Theory, RepeatData(Repeats)]
  public void Merge_ThreeItemsDifferentAliases_ReturnsExpected(string name1, string name2, string alias1, string alias2)
  => Merge_Expected([MakeAliased(name1, []), MakeAliased(name2, [alias1]), MakeAliased(name1, [alias2])],
    alias1 == alias2, MakeAliased(name1, [alias2]), MakeAliased(name2, [alias1]));

  [Theory, RepeatData(Repeats)]
  public void Merge_ThreeItemsTwoAliases_ReturnsExpected(string name1, string name2, string alias1, string alias2)
  => Merge_Expected([MakeAliased(name1, [alias1]), MakeAliased(name2, []), MakeAliased(name1, [alias2])],
    alias1 == alias2, MakeAliased(name1, [alias1, alias2]), MakeAliased(name2, []));

  protected abstract TItem MakeAliased(string name, string[] aliases, string description = "");
  protected override TItem MakeDescribed(string name, string description = "")
    => MakeAliased(name, [], description);
}
