using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class AstAlternatesMerger<TAlternate, TObjBase>(
  ILoggerFactory logger
) : AstDescribedMerger<TAlternate>(logger)
  where TAlternate : AstAlternate<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>, IEquatable<TObjBase>
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

internal class AlternatesMerger<TObjBase>(
  ILoggerFactory logger
) : AstAlternatesMerger<AstAlternate<TObjBase>, TObjBase>(logger)
  where TObjBase : AstObjectBase<TObjBase>, IEquatable<TObjBase>
{ }
