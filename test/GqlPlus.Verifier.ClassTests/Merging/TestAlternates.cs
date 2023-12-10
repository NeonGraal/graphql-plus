using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAlternates<TAlternate, TReference>
  : TestDescriptions<TAlternate>
  where TAlternate : AlternateAst<TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{
  protected abstract AlternatesMerger<TAlternate, TReference> MergerAlternate { get; }
  protected override DescribedMerger<TAlternate> MergerDescribed => MergerAlternate;

  protected abstract TAlternate MakeAlternate(string name, string description = "");
  protected override TAlternate MakeDescribed(string name, string description = "")
    => MakeAlternate(name, description);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameModifers_ReturnsTrue(string input)
  {
    var items = new[] { MakeAlternate(input) with { Modifiers = TestMods() }, MakeAlternate(input) with { Modifiers = TestMods() } };

    var result = MergerAlternate.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentModifers_ReturnsFalse(string input)
  {
    var items = new[] { MakeAlternate(input) with { Modifiers = TestMods() }, MakeAlternate(input) };

    var result = MergerAlternate.CanMerge(items);

    result.Should().BeFalse();
  }
}

public abstract class TestAlternates<TReference>
  : TestAlternates<AlternateAst<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
