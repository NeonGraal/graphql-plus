using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestDescriptions<TAst>
  : TestGroups<TAst>
  where TAst : AstAbbreviated, IAstDescribed
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDescription_ReturnsTrue(string name, string description)
    => CanMerge_True([MakeDescribed(name), MakeDescribed(name, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDescription_ReturnsTrue(string name, string description)
  => CanMerge_True([MakeDescribed(name, description), MakeDescribed(name, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDescription_ReturnsFalse(string name, string description1, string description2)
  => CanMerge_False([MakeDescribed(name, description1), MakeDescribed(name, description2)], description1 == description2);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDescription_ReturnsExpected(string name, string description)
    => Merge_Expected([MakeDescribed(name), MakeDescribed(name, description)], MakeDescribed(name, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameDescription_ReturnsExpected(string name, string description)
  => Merge_Expected([MakeDescribed(name, description), MakeDescribed(name, description)], MakeDescribed(name, description));

  protected abstract TAst MakeDescribed(string name, string description = "");
  protected override TAst MakeAst(string name)
    => MakeDescribed(name);
}
