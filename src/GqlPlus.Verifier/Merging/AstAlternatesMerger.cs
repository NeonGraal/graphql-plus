using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class AstAlternatesMerger<TAlternate, TRef>
  : AstDescribedMerger<TAlternate>
  where TAlternate : AstAlternate<TRef>
  where TRef : AstReference<TRef>, IEquatable<TRef>
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

internal class AlternatesMerger<TRef>
  : AstAlternatesMerger<AstAlternate<TRef>, TRef>
  where TRef : AstReference<TRef>, IEquatable<TRef>
{ }
