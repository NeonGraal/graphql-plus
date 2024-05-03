using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Merging.Objects;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAlternates<TAlternate, TObjBase>
  : TestDescriptions<TAlternate>
  where TAlternate : AstAlternate<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>, IEquatable<TObjBase>
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

  internal abstract AstAlternatesMerger<TAlternate, TObjBase> MergerAlternate { get; }
  internal override GroupsMerger<TAlternate> MergerGroups => MergerAlternate;

  protected abstract TAlternate MakeAlternate(string name, string description = "");
  protected override TAlternate MakeDescribed(string name, string description = "")
    => MakeAlternate(name, description);
}

public abstract class TestAlternates<TObjBase>
  : TestAlternates<AstAlternate<TObjBase>, TObjBase>
  where TObjBase : AstObjectBase<TObjBase>, IEquatable<TObjBase>
{ }
