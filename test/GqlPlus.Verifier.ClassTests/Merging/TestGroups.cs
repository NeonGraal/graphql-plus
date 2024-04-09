using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestGroups<TAst>
  : TestAbbreviated<TAst>
  where TAst : AstAbbreviated
{
  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentNames_ReturnsTrue(string name1, string name2)
  {
    Skip.If(SkipDifferentNames || name1 == name2);

    CanMerge_True([MakeAst(name1), MakeAst(name2)]);
  }

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstsDifferentName_ReturnsAsts(string name1, string name2)
  {
    Skip.If(SkipDifferentNames || name1 == name2);

    var ast1 = MakeAst(name1);
    var ast2 = MakeAst(name2);

    Merge_Expected([ast1, ast2], ast2, ast1);
  }

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstSameName_ReturnsFirst(string name)
  {
    var ast1 = MakeAst(name);
    var ast2 = MakeAst(name);

    Merge_Expected([ast1, ast2], ast1);
  }

  protected virtual bool SkipDifferentNames => false;

  internal abstract GroupsMerger<TAst> MergerGroups { get; }

  protected override IMerge<TAst> MergerBase => MergerGroups;
}
