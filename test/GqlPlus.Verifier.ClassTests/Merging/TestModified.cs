using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class TestModified<TModified>
  : TestDescriptions<TModified>
  where TModified : AstBase, IAstDescribed, IAstModified
{

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameModifers_ReturnsTrue(string input)
  {
    var items = new[] { MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() } };

    var result = MergerDescribed.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentModifers_ReturnsFalse(string input)
  {
    var items = new[] { MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) };

    var result = MergerDescribed.CanMerge(items);

    result.Should().BeFalse();
  }
}
