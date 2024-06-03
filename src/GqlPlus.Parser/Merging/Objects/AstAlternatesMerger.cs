using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class AstAlternatesMerger<TAlternate, TObjBase>(
  ILoggerFactory logger
) : AstDescribedMerger<TAlternate>(logger)
  where TAlternate : AstAlternate<TObjBase>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  protected override TAlternate MergeGroup(IEnumerable<TAlternate> group)
  {
    TAlternate first = group.First();
    if (first.Type is IAstSetDescription descrType)
    {
      descrType.MakeDescription(group);
    }

    return first;
  }

  protected override string ItemGroupKey(TAlternate item)
    => item.Type.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(TAlternate item)
    => item.Modifiers.AsString().Joined();
}

internal class AlternatesMerger<TObjBase>(
  ILoggerFactory logger
) : AstAlternatesMerger<AstAlternate<TObjBase>, TObjBase>(logger)
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{ }
