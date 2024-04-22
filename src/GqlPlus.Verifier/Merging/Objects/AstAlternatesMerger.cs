using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class AstAlternatesMerger<TAlternate, TRef>(
  ILoggerFactory logger
) : AstDescribedMerger<TAlternate>(logger)
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

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(TAlternate item)
    => item.Modifiers.AsString().Joined();
}

internal class AlternatesMerger<TRef>(
  ILoggerFactory logger
) : AstAlternatesMerger<AstAlternate<TRef>, TRef>(logger)
  where TRef : AstReference<TRef>, IEquatable<TRef>
{ }
