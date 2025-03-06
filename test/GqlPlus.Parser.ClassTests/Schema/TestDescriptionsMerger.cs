using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Schema;

public abstract class TestDescriptionsMerger<TAst>
  : TestGroupsMerger<TAst, string>
  where TAst : IGqlpError, IGqlpDescribed
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneDescription_ReturnsGood(string name, string description)
    => CanMerge_Good(MakeDescribed(name), MakeDescribed(name, description));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameDescription_ReturnsGood(string name, string description)
    => CanMerge_Good(MakeDescribed(name, description), MakeDescribed(name, description));

  [SkippableTheory, RepeatData]
  public void CanMerge_TwoAstsDifferentDescription_ReturnsErrors(string name, string description1, string description2)
    => this
      .SkipIf(description1 == description2)
      .CanMerge_Errors(MakeDescribed(name, description1), MakeDescribed(name, description2));

  [Theory, RepeatData]
  public void Merge_TwoAstsOneDescription_ReturnsExpected(string name, string description)
    => Merge_Expected(
      [MakeDescribed(name), MakeDescribed(name, description)],
      MakeDescribed(name, description));

  [Theory, RepeatData]
  public void Merge_TwoAstsSameDescription_ReturnsExpected(string name, string description)
    => Merge_Expected(
      [MakeDescribed(name, description), MakeDescribed(name, description)],
      MakeDescribed(name, description));

  protected abstract TAst MakeDescribed(string name, string description = "");
  protected override TAst MakeAst(string input)
    => MakeDescribed(input);
}
