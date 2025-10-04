using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeObjAlts(
  ILoggerFactory logger
) : AstDescribedMerger<IGqlpObjAlt>(logger)
{
  protected override IGqlpObjAlt MergeGroup(IEnumerable<IGqlpObjAlt> group)
  {
    IGqlpObjAlt first = group.First();
    if (first is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first;
  }

  protected override string ItemGroupKey(IGqlpObjAlt item)
    => item.FullType + item.EnumValue?.EnumLabel.Prefixed(".");

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IGqlpObjAlt item)
    => item.Modifiers.AsString().Joined();
}
