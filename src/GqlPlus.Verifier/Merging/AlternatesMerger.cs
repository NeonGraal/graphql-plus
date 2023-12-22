using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class AlternatesMerger<TAlternate, TReference>
  : DescribedMerger<TAlternate>
  where TAlternate : AlternateAst<TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{
  protected override TAlternate MergeGroup(TAlternate[] items)
  {
    var first = items.First();
    return first with { Type = first.Type with { Description = items.MergeDescriptions() } };
  }

  public override bool CanMerge(TAlternate[] items)
    => base.CanMerge(items);

  protected override string ItemGroupKey(TAlternate item)
    => item.Type.TypeName;

  protected override string ItemMatchKey(TAlternate item)
    => item.Modifiers.AsString().Joined();
}

internal class AlternatesMerger<TReference>
  : AlternatesMerger<AlternateAst<TReference>, TReference>
  where TReference : AstReference<TReference>, IEquatable<TReference>
{ }
