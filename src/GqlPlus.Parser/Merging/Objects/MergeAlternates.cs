using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeAlternates(
  IMergerRepository mergers
) : AstDescribedMerger<IAstAlternate>(mergers)
{
  protected override IAstAlternate MergeGroup(IEnumerable<IAstAlternate> group)
  {
    IAstAlternate first = group.First();
    if (first is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first;
  }

  protected override string ItemGroupKey(IAstAlternate item)
    => item.FullType + item.EnumValue?.EnumLabel.Prefixed(".");

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IAstAlternate item)
    => item.Modifiers.AsString().Joined();

  internal static MergeAlternates Factory(IMergerRepository m) => new(m);
}
