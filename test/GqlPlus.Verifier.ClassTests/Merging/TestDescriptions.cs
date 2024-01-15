using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestDescriptions<TItem>
  : TestGroups<TItem>
  where TItem : AstAbbreviated, IAstDescribed
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneDescription_ReturnsTrue(string name, string description)
    => CanMerge_True([MakeDescribed(name), MakeDescribed(name, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDescription_ReturnsTrue(string name, string description)
  => CanMerge_True([MakeDescribed(name, description), MakeDescribed(name, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDescription_ReturnsFalse(string name, string description1, string description2)
  => CanMerge_False([MakeDescribed(name, description1), MakeDescribed(name, description2)], description1 == description2);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsOneDescription_ReturnsExpected(string name, string description)
    => Merge_Expected([MakeDescribed(name), MakeDescribed(name, description)], MakeDescribed(name, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsSameDescription_ReturnsExpected(string name, string description)
  => Merge_Expected([MakeDescribed(name, description), MakeDescribed(name, description)], MakeDescribed(name, description));

  protected abstract TItem MakeDescribed(string name, string description = "");
  protected override TItem MakeDistinct(string name)
    => MakeDescribed(name);
}
