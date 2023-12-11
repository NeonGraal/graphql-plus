using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestAlternates<TAlternate, TReference>
  : TestModified<TAlternate>
  where TAlternate : AlternateAst<TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{
  protected abstract AlternatesMerger<TAlternate, TReference> MergerAlternate { get; }
  protected override DescribedsMerger<TAlternate> MergerDescribed => MergerAlternate;

  protected abstract TAlternate MakeAlternate(string name, string description = "");
  protected override TAlternate MakeDescribed(string name, string description = "")
    => MakeAlternate(name, description);
}

public abstract class TestAlternates<TReference>
  : TestAlternates<AlternateAst<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
