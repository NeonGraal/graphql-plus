using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Schema;

public abstract class TestDescriptionsMerger<TAst>
  : TestDescriptionsMerger<TAst, string>
  where TAst : IGqlpError, IGqlpDescribed
{ }

public abstract class TestDescriptionsMerger<TAst, TInput>
  : TestGroupsMerger<TAst, TInput>
  where TAst : IGqlpError, IGqlpDescribed
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneDescription_ReturnsGood(TInput input, string description)
  => CanMerge_Good(MakeDescribed(input), MakeDescribed(input, description));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameDescription_ReturnsGood(TInput input, string description)
    => CanMerge_Good(MakeDescribed(input, description), MakeDescribed(input, description));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentDescription_ReturnsGood(TInput input, string description1, string description2)
    => this
      .SkipIf(description1 == description2)
      .CanMerge_Good(MakeDescribed(input, description1), MakeDescribed(input, description2));

  [Theory, RepeatData]
  public void Merge_TwoAstsOneDescription_ReturnsExpected(TInput input, string description)
    => Merge_Expected(
      [MakeDescribed(input), MakeDescribed(input, description)],
      MakeDescribed(input, description));

  [Theory, RepeatData]
  public void Merge_TwoAstsSameDescription_ReturnsExpected(TInput input, string description)
    => Merge_Expected(
      [MakeDescribed(input, description), MakeDescribed(input, description)],
      MakeDescribed(input, description + " " + description));

  protected abstract TAst MakeDescribed(TInput input, string description = "");
  protected override TAst MakeAst(TInput input)
    => MakeDescribed(input);
}
