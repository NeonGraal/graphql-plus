using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestScalarItems<TItem>
  : TestGroups<TItem>
  where TItem : AstAbbreviated, IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSame_ReturnsGood(string name)
    => CanMerge_Good([MakeAst(name), MakeAst(name)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSame_ReturnsExpected(string name)
    => Merge_Expected(
      [MakeAst(name), MakeAst(name)],
      MakeAst(name));

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstsDifferent_ReturnsExpected(string name1, string name2)
    => Merge_Expected(
      [MakeAst(name1), MakeAst(name2)],
      name1 == name2, MakeAst(name1), MakeAst(name2));
}
