using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class AstObjectFieldsMerger<TObjField>(
  ILoggerFactory logger
) : AstAliasedMerger<TObjField>(logger)
  where TObjField : IGqlpObjField
{
  protected override string ItemMatchName => "ModifiedType";
  protected override string ItemMatchKey(TObjField item)
    => item.ModifiedType;

  protected override TObjField MergeGroup(IEnumerable<TObjField> group)
  {
    TObjField result = base.MergeGroup(group);
    if (result.Type is IAstSetDescription descrType) {
      descrType.MakeDescription(group.Select(item => item.Type));
    }

    return result;
  }
}
