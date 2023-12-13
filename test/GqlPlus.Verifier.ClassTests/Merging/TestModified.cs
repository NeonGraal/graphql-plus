using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestModified<TModified>
  : TestDescriptions<TModified>
  where TModified : AstBase, IAstDescribed, IAstModified
{

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameModifers_ReturnsTrue(string input)
    => CanMerge_True([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentModifers_ReturnsFalse(string input)
    => CanMerge_False([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input)]);
}
