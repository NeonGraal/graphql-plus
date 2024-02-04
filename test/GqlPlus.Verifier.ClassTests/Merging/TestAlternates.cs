using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAlternates<TAlternate, TReference>
  : TestDescriptions<TAlternate>
  where TAlternate : AstAlternate<TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameModifers_ReturnsTrue(string input)
    => CanMerge_True([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsFalse(string input)
    => CanMerge_False([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }],
      MakeDescribed(input) with { Modifiers = TestMods() });

  internal abstract AstAlternatesMerger<TAlternate, TReference> MergerAlternate { get; }
  internal override GroupsMerger<TAlternate> MergerGroups => MergerAlternate;

  protected abstract TAlternate MakeAlternate(string name, string description = "");
  protected override TAlternate MakeDescribed(string name, string description = "")
    => MakeAlternate(name, description);
}

public abstract class TestAlternates<TReference>
  : TestAlternates<AstAlternate<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
