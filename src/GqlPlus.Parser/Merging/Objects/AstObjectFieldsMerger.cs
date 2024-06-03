using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class AstObjectFieldsMerger<TObjField, TObjBase>(
  ILoggerFactory logger
) : AstAliasedMerger<TObjField>(logger)
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  protected override string ItemMatchName => "ModifiedType";
  protected override string ItemMatchKey(TObjField item)
    => item.ModifiedType;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TObjField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Type.Description));

  protected override TObjField MergeGroup(IEnumerable<TObjField> group)
  {
    TObjField result = base.MergeGroup(group);
    if (result.Type is IAstSetDescription descrType)
    {
      descrType.MakeDescription(group.Select(item => item.Type));
    }

    return result;
  }
}
