using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public abstract class TestAlternates<TObjBase>
  : TestDescriptions<IGqlpAlternate<TObjBase>>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameModifers_ReturnsGood(string input)
    => CanMerge_Good([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsErrors(string input)
    => CanMerge_Errors([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }],
      MakeDescribed(input) with { Modifiers = TestMods() });

  internal abstract AstAlternatesMerger<IGqlpAlternate<TObjBase>, TObjBase> MergerAlternate { get; }
  internal override GroupsMerger<IGqlpAlternate<TObjBase>> MergerGroups => MergerAlternate;

  protected abstract AstAlternate<TObjBase> MakeAlternate(string name, string description = "");
  protected override AstAlternate<TObjBase> MakeDescribed(string name, string description = "")
    => MakeAlternate(name, description);
}
