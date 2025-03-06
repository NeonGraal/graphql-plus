using GqlPlus.Merging;

namespace GqlPlus.Schema;

public abstract class TestGroupsMerger<TAst, TInput>
  : TestAbbreviatedMerger<TAst, TInput>
  where TAst : IGqlpError
{
  [SkippableTheory, RepeatData]
  public void CanMerge_TwoAstsDifferentNames_ReturnsGood(TInput input1, TInput input2)
  {
    Skip.If(SkipDifferentInput || input1 is null || input1.Equals(input2));

    CanMerge_Good([MakeAst(input1), MakeAst(input2)]);
  }

  [SkippableTheory, RepeatData]
  public void Merge_TwoAstsDifferentName_ReturnsAsts(TInput input1, TInput input2)
  {
    Skip.If(SkipDifferentInput || input1 is null || input1.Equals(input2));

    TAst ast1 = MakeAst(input1);
    TAst ast2 = MakeAst(input2);

    Merge_Expected([ast1, ast2], ast2, ast1);
  }

  [SkippableTheory, RepeatData]
  public void Merge_TwoAstSameName_ReturnsFirst(TInput input)
  {
    TAst ast1 = MakeAst(input);
    TAst ast2 = MakeAst(input);

    Merge_Expected([ast1, ast2], ast1);
  }

  protected virtual bool SkipDifferentInput => false;

  internal abstract GroupsMerger<TAst> MergerGroups { get; }

  protected override IMerge<TAst> MergerBase => MergerGroups;
}
