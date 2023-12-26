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
  public void CanMerge_TwoItemsDifferentalias_ReturnsTrue(string name, string alias1, string alias2)
  => CanMerge_True([MakeAliased(name, [alias1]), MakeAliased(name, [alias2])]);

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

  protected abstract TItem MakeAliased(string name, string[] aliases, string description = "");
  protected override TItem MakeDescribed(string name, string description = "")
    => MakeAliased(name, [], description);
}
