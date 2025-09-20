using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeObjAlternates(
  ILoggerFactory logger
) : AstDescribedMerger<IGqlpObjAlternate>(logger)
{
  protected override IGqlpObjAlternate MergeGroup(IEnumerable<IGqlpObjAlternate> group)
  {
    IGqlpObjAlternate first = group.First();
    if (first is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first;
  }

  protected override string ItemGroupKey(IGqlpObjAlternate item)
    => item.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IGqlpObjAlternate item)
    => item.Modifiers.AsString().Joined();
}
