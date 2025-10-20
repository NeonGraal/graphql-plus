using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeAlternates(
  ILoggerFactory logger
) : AstDescribedMerger<IGqlpAlternate>(logger)
{
  protected override IGqlpAlternate MergeGroup(IEnumerable<IGqlpAlternate> group)
  {
    IGqlpAlternate first = group.First();
    if (first is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first;
  }

  protected override string ItemGroupKey(IGqlpAlternate item)
    => item.FullType + item.EnumValue?.EnumLabel.Prefixed(".");

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IGqlpAlternate item)
    => item.Modifiers.AsString().Joined();
}
