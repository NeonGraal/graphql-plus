using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class AstAlternatesMerger<TAlternate>(
  ILoggerFactory logger
) : AstDescribedMerger<TAlternate>(logger)
  where TAlternate : IGqlpObjAlternate
{
  protected override TAlternate MergeGroup(IEnumerable<TAlternate> group)
  {
    TAlternate first = group.First();
    if (first is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first;
  }

  protected override string ItemGroupKey(TAlternate item)
    => item.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(TAlternate item)
    => item.Modifiers.AsString().Joined();
}
