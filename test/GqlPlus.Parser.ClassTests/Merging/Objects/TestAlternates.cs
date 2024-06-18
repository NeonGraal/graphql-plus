using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public abstract class TestAlternates<TObjAlt, TObjAltAst, TObjBase>
  : TestDescriptions<TObjAlt>
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
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

  internal abstract AstAlternatesMerger<TObjAlt, TObjBase> MergerAlternate { get; }
  internal override GroupsMerger<TObjAlt> MergerGroups => MergerAlternate;

  protected abstract TObjAltAst MakeAlternate(string name, string description = "");
  protected override TObjAltAst MakeDescribed(string name, string description = "")
    => MakeAlternate(name, description);
}
