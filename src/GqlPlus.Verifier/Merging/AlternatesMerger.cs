using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class AlternatesMerger<TAlternate, TReference>
  : DescribedMerger<TAlternate>
  where TAlternate : AlternateAst<TReference>
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
  : AlternatesMerger<AlternateAst<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
