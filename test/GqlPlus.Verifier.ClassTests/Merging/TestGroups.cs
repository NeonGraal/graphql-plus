using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestGroups<TAst>
  : TestAbbreviated<TAst>
  where TAst : AstAbbreviated
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentNames_ReturnsTrue(string name1, string name2)
  {
    if (name1 == name2) {
      return;
    }

    CanMerge_True([MakeDistinct(name1), MakeDistinct(name2)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsDifferentName_ReturnsAsts(string name1, string name2)
  {
    var ast1 = MakeDistinct(name1);
    var ast2 = MakeDistinct(name2);

    Merge_Expected([ast1, ast2], name1 == name2, ast2, ast1);
  }

  internal abstract GroupsMerger<TAst> MergerGroups { get; }

  protected override IMerge<TAst> MergerBase => MergerGroups;
}
