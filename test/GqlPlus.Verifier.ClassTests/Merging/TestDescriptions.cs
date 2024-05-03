using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public abstract class TestDescriptions<TAst>
  : TestGroups<TAst>
  where TAst : AstAbbreviated, IAstDescribed
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDescription_ReturnsGood(string name, string description)
    => CanMerge_Good(MakeDescribed(name), MakeDescribed(name, description));

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDescription_ReturnsGood(string name, string description)
    => CanMerge_Good(MakeDescribed(name, description), MakeDescribed(name, description));

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDescription_ReturnsErrors(string name, string description1, string description2)
    => this
      .SkipIf(description1 == description2)
      .CanMerge_Errors(MakeDescribed(name, description1), MakeDescribed(name, description2));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDescription_ReturnsExpected(string name, string description)
    => Merge_Expected(
      [MakeDescribed(name), MakeDescribed(name, description)],
      MakeDescribed(name, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameDescription_ReturnsExpected(string name, string description)
    => Merge_Expected(
      [MakeDescribed(name, description), MakeDescribed(name, description)],
      MakeDescribed(name, description));

  protected abstract TAst MakeDescribed(string name, string description = "");
  protected override TAst MakeAst(string input)
    => MakeDescribed(input);
}
