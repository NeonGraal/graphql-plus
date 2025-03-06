﻿using GqlPlus.Merging;

namespace GqlPlus.Schema;

public abstract class TestGroupsMerger<TAst, TInput>
  : TestAbbreviatedMerger<TAst, TInput>
  where TAst : IGqlpError
{
  [SkippableTheory, RepeatData]
  public void CanMerge_TwoAstsDifferentNames_ReturnsGood(TInput name1, TInput name2)
  {
    Skip.If(SkipDifferentNames || name1 is null || name1.Equals(name2));

    CanMerge_Good([MakeAst(name1), MakeAst(name2)]);
  }

  [SkippableTheory, RepeatData]
  public void Merge_TwoAstsDifferentName_ReturnsAsts(TInput name1, TInput name2)
  {
    Skip.If(SkipDifferentNames || name1 is null || name1.Equals(name2));

    TAst ast1 = MakeAst(name1);
    TAst ast2 = MakeAst(name2);

    Merge_Expected([ast1, ast2], ast2, ast1);
  }

  [SkippableTheory, RepeatData]
  public void Merge_TwoAstSameName_ReturnsFirst(TInput name)
  {
    TAst ast1 = MakeAst(name);
    TAst ast2 = MakeAst(name);

    Merge_Expected([ast1, ast2], ast1);
  }

  protected virtual bool SkipDifferentNames => false;

  internal abstract GroupsMerger<TAst> MergerGroups { get; }

  protected override IMerge<TAst> MergerBase => MergerGroups;
}
