using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class AstAlternatesMerger<TAlternate, TReference>
  : AstDescribedMerger<TAlternate>
  where TAlternate : AstAlternate<TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{
  protected override TAlternate MergeGroup(IEnumerable<TAlternate> group)
  {
    var first = group.First();
    return first with { Type = first.Type with { Description = group.MergeDescriptions() } };
  }

  protected override string ItemGroupKey(TAlternate item)
    => item.Type.FullName;

  protected override string ItemMatchKey(TAlternate item)
    => item.Modifiers.AsString().Joined();
}

internal class AlternatesMerger<TReference>
  : AstAlternatesMerger<AstAlternate<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
